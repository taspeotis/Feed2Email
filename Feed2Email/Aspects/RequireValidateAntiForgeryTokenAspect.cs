using System;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;
using PostSharp.Aspects;
using PostSharp.Extensibility;

namespace Feed2Email.Aspects
{
    [Serializable]
    public class RequireValidateAntiForgeryTokenAspect : MethodLevelAspect
    {
        public override bool CompileTimeValidate(MethodBase method)
        {
            // MethodBase can be used to represent constructors
            if (method.MemberType == MemberTypes.Method)
            {
                var methodAttributes = method.GetCustomAttributes(true);

                if (methodAttributes.Any(a => a is HttpPostAttribute) &&
                    !methodAttributes.Any(a => a is ValidateAntiForgeryTokenAttribute))
                {
                    Message.Write(method, SeverityType.Error, GetType().Name,
                        "{0}.{1} has an HttpPostAttribute but no ValidateAntiForgeryTokenAttribute",
                        // ReSharper disable once PossibleNullReferenceException
                        method.DeclaringType.Name, method.Name);

                    return false;
                }
            }

            return true;
        }
    }
}