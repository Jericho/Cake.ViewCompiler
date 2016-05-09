using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cake.Core.IO;
using Newtonsoft.Json.Linq;

namespace Cake.ViewCompiler
{
    public class DesignDocument
    {
        private string _id;
        public Dictionary<string, string> Views { get; set; }

        public string Id
        {
            get { return $"_design/{_id}"; }
            set
            {
                if (value.Contains("_design"))
                {
                    value = value.Replace("_design", string.Empty);
                }
                if (value.Contains("/"))
                {
                    value = value.Replace("/", string.Empty);
                }
                _id = value;
            }
        }

        public void AddView(string name, string function)
        {
            Views.Add(name, function);
        }

        public string Language { get; set; } = "javascript";

        private string ToDesignDoc()
        {
            var j = new JObject();
            j.Add("_id", Id);
            var viewObj = new JObject();
            foreach (var view in Views)
            {
                viewObj.Add(view.Key, new JObject("map", view.Value));
            }
            j.Add("views", viewObj);
            j.Add("language", Language);
            return j.ToString();
        }

        public FilePath Create(FilePath path)
        {
            File.WriteAllText(path.FullPath, this.ToDesignDoc());
            return path;
        }
    }
}
