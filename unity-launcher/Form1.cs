using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.IO;
using System.Windows.Forms;

namespace unity_launcher
{
    public partial class Form1 : Form
    {
        private class PathButton
        {
            public Button Button;
            public string Path;
            public string Arguments;
        }

        private class Project {
            public string Name;
            public string UnityVersion;
            public string Path;
        }

        private List<PathButton> unitys = new List<PathButton>();
        private List<PathButton> projects = new List<PathButton>();

        public Form1()
        {
            InitializeComponent();

            var args = Environment.GetCommandLineArgs();

            string path = null;

            string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            var defaultFile = Path.Combine(desktop, "unity-launcher.txt");

            if (File.Exists(defaultFile))
            {
                path = defaultFile;
            }
            else if (args.Length > 1)
            {
                path = args[1];

                if (!File.Exists(path))
                {
                    MessageBox.Show(string.Format("File {0} missing!", path), "Unity versions missing!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                    // close soon
                    CloseSoon();

                    return;
                }
            }
            else
            {
                MessageBox.Show("You need to specify a text file with the unity versions as the 1. command line argument.", "Unity versions missing!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                CloseSoon();

                return;
            }

            Dictionary<string, string> unitys = new Dictionary<string, string>()
            {
                {"unity 5.3", "C:\\Program Files\\Unity-5.3\\Editor\\Unity.exe"},
                {"unity 5.6", "C:\\Program Files\\Unity-5.6\\Editor\\Unity.exe"},
            };

            unitys.Clear();

            // ignore empty lines or comments
            var lines = System.IO.File.ReadAllLines(path)
                .Where(it => it.Trim().Length > 0 && it.Trim()[0] != '#')
                .ToList();

            List<string> projectRoots = new List<string>();

            int i = 0;

            for(; i < lines.Count && lines[i] != "---"; i += 2)
            {
                var n = lines[i + 0];
                var p = lines[i + 1];
                unitys[n] = p;
            }

            // skip the marker
            ++i;

            for (; i < lines.Count; i += 1) {
                var n = lines[i];
                projectRoots.Add(n);
            }

            List<Project> projects = new List<Project>();
            foreach(var root in projectRoots) {
                var assetFolders = FindAssetsFolders(root);
                projects.AddRange(assetFolders.Select(it => GetProjectInfo(it, root)).Where(it => it != null));
            }

            foreach (var it in unitys)
            {
                var control = new Button() {
                    Text = it.Key,
                };
                this.unitys.Add(new PathButton()
                {
                    Button = control,
                    Path = it.Value,
                });
                control.Click += Control_Click;

                var tooltip = new ToolTip();
                control.MouseHover += new EventHandler(delegate (object sender, EventArgs e)
                {
                    var btn = (Button)sender;
                    tooltip.SetToolTip(btn, it.Value);
                });

                flowLayoutPanel1.Controls.Add(control);
            }

            foreach(var it in projects.OrderBy(it => it.Name)) {
                var unity = FindBestUnityVersion(unitys, it.UnityVersion);
                if (unity == null) continue;

                var control = new Button() {
                    Text = string.Format("{0} | {1}", it.Name, it.UnityVersion),
                    Width = 400,
                    TextAlign = System.Drawing.ContentAlignment.MiddleLeft,
                };
                this.unitys.Add(new PathButton() {
                    Button = control,
                    Path = unity,
                    Arguments = string.Format("-projectPath \"{0}\"", it.Path),
                });
                control.Click += Control_Click;

                var tooltip = new ToolTip();
                control.MouseHover += new EventHandler(delegate (object sender, EventArgs e)
                {
                    var btn = (Button)sender;
                    tooltip.SetToolTip(btn, it.Path);
                });

                flowLayoutPanel1.Controls.Add(control);
            }


            // place near mouse
            {
                var self = this;
                System.Threading.Thread t = new System.Threading.Thread(() => {
                    System.Threading.Thread.Sleep(5);
                    self.Invoke(new Action(() => {
                        var mousePos = System.Windows.Forms.Cursor.Position;
                        var pos = mousePos - self.Size;
                        var border = 20;
                        pos.X -= border;
                        pos.Y -= border;
                        pos.X = Math.Max(border, pos.X);
                        pos.Y = Math.Max(border, pos.Y);
                        this.DesktopLocation = pos;
                    }));
                });
                t.Start();                
            }
        }

        private string FindBestUnityVersion(Dictionary<string, string> unitys, string unityVersion) {
            if (unitys.ContainsKey(unityVersion)) return unitys[unityVersion];
            return unitys.Where(it => unityVersion.StartsWith(it.Key)).FirstOrDefault().Value;
        }

        private Project GetProjectInfo(string pathToAssets, string removePrefixInPath) {
            try {
                var path = pathToAssets.Substring(0, pathToAssets.Length - "\\Assets".Length);
                var version = File.ReadAllText(path + "\\ProjectSettings\\ProjectVersion.txt").Replace("m_EditorVersion: ", "").Trim();
                return new Project() {
                    Path = path,
                    Name = path.Replace(removePrefixInPath, "").Trim().Trim('\\', '/'),
                    UnityVersion = version,
                };
            }
            catch {
                return null;
            }
        }

        private IEnumerable<string> FindAssetsFolders(string root) {
            return EnumDirectoriesDeep(root, it => it.Contains("\\.") || it.Contains("/.") || 
                it.EndsWith("\\Library") || it.EndsWith("/Library") || 
                it.EndsWith("\\Assets") || it.EndsWith("/Assets"))
                    .Where(it => it.EndsWith("/Assets") || it.EndsWith("\\Assets"));
        }

        private void CloseSoon() {
            // close soon
            var self = this;
            System.Threading.Thread t = new System.Threading.Thread(() => {
                System.Threading.Thread.Sleep(5);
                self.Invoke(new Action(() => self.Close()));
            });
            t.Start();
        }

        private void Control_Click(object sender, EventArgs e)
        {
            {
                var pathButton = unitys.FirstOrDefault(it => it.Button == sender);
                if (pathButton != null)
                {
                    if (string.IsNullOrEmpty(pathButton.Arguments)) System.Diagnostics.Process.Start(pathButton.Path);
                    else System.Diagnostics.Process.Start(pathButton.Path, pathButton.Arguments);
                    Close();
                }
            }

            {
                var project = projects.FirstOrDefault(it => it.Button == sender);
                if (project != null) {
                    System.Diagnostics.Process.Start(project.Path);
                    Close();
                }
            }
        }

        public static IEnumerable<string> EnumDirectoriesDeep(string root, Func<string, bool> callbackSkip) {
            yield return root;

            foreach (string d in Directory.GetDirectories(root)) {
                if (callbackSkip(d)) yield return d;
                else foreach (var it in EnumDirectoriesDeep(d, callbackSkip)) {
                    yield return it;
                }
            }
        }

        public static IEnumerable<string> EnumFilesDeep(string root, Func<string, bool> callbackSkip) {
            foreach (string f in Directory.GetFiles(root)) {
                if (callbackSkip(f)) continue;
                yield return f;
            }

            foreach (string d in Directory.GetDirectories(root)) {
                if (callbackSkip(d)) continue;
                foreach (var it in EnumFilesDeep(d, callbackSkip)) {
                    if (callbackSkip(it)) continue;
                    yield return it;
                }
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Escape) {
                this.Close();
            }
        }

        private void Form1_Load(object sender, EventArgs e) {

        }
    }
}
