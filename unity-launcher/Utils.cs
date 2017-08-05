using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace unity_launcher {
    public static class Utils {

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

    }
}
