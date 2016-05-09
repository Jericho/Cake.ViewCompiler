﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cake.Core;
using Cake.Core.Annotations;
using Cake.Core.IO;

namespace Cake.ViewCompiler
{
    public static class ViewCompilerAliases
    {
        [CakeMethodAlias]
        public static Compiler ViewCompiler(this ICakeContext context, string id)
        {
            if (context == null) throw new ArgumentNullException(nameof(context));
            return new Compiler(context, id);
        }
    }

    public class Compiler
    {
        private Compiler(string id)
        {
            this.Id = id;
        }

        private string Id { get; set; }

        public Compiler(ICakeContext context, string id) : this(id)
        {
            //this.Context = context;
        }

        public DesignDocument FromFiles(IEnumerable<FilePath> files)
        {
            var dict = new Dictionary<string, string>();
            foreach (var filePath in files)
            {
                var s = filePath.GetFilenameWithoutExtension().ToString();
                //new FileInfo(filePath.FullPath).Name
                dict.Add(s, File.ReadAllText(filePath.FullPath));
            }
            var doc = new DesignDocument()
            {
                Id = Id,
                Views = dict
            };
            return doc;
        }
    }
}
