using System;
using Cake.Core;
using Cake.Core.Annotations;

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
}