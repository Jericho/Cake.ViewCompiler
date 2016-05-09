using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cake.Core;
using Cake.Core.IO;

namespace Cake.ViewCompiler
{
    public class Compiler
    {
        private Compiler(string id)
        {
            this.Id = id;
            Document = new DesignDocument
            {
                Id = id
            };
        }

        private string Id { get; set; }

        public Compiler(ICakeContext context, string id) : this(id)
        {
            //this.Context = context;
        }

        public Compiler FromFiles(IEnumerable<FilePath> files)
        {
            foreach (var filePath in files)
            {
                var s = filePath.GetFilenameWithoutExtension().ToString();
                //new FileInfo(filePath.FullPath).Name
                Document.Views.Add(s, File.ReadAllText(filePath.FullPath));
            }
            return this;
        }

        public Compiler FromFile(FilePath file)
        {
            var s = file.GetFilenameWithoutExtension().ToString();
            Document.Views.Add(s, File.ReadAllText(file.FullPath));
            return this;
        }

        public Compiler WriteToFile(FilePath file)
        {
            Document.Create(file);
            return this;
        }

        private DesignDocument Document { get; set; }
    }
}
