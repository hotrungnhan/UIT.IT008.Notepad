using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nodepad.component.Enum
{
    public enum LangCode
    {
        Plain = 0,
        CSharp = 2,
        Cpp = 1,
        Java = 4,
        JavaScript = 3
    };
    public class LangFunc
    {
        static public LangCode getCodeByExtension(string ets)
        {
            switch (ets)
            {
                case ".cpp": case ".h": return LangCode.Cpp;
                case ".js":
                    return LangCode.JavaScript;
                case ".jav":
                case ".class":
                    return LangCode.Java;
                case ".cs":
                    return LangCode.CSharp;
                default:
                    return LangCode.Plain;
            }
        }
    }
    public enum FileState
    {
        unsave,
        save,
    }
}
