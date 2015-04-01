using System.CodeDom;
using TechTalk.SpecFlow.Generator;
using TechTalk.SpecFlow.Generator.UnitTestProvider;
using TechTalk.SpecFlow.Utils;

namespace MsTestContext
{
    public class CustomGeneratorProvider : MsTest2010GeneratorProvider
    {

        public CustomGeneratorProvider(CodeDomHelper codeDomHelper)
            : base(codeDomHelper)
        {
        }

        public override void SetTestClassInitializeMethod(TestClassGenerationContext generationContext)
        {


            // Adding TestContext as field

            var field = new CodeMemberField()
            {
                Name = "testContext",
                Type = new CodeTypeReference("Microsoft.VisualStudio.TestTools.UnitTesting.TestContext"),
                Attributes = MemberAttributes.Private
            };

            // Adding TestContext properties

            generationContext.TestClass.Members.Add(field);

            var codeMemberProperty = new CodeMemberProperty();
            codeMemberProperty.Name = "TestContext";
            codeMemberProperty.Type = new CodeTypeReference("Microsoft.VisualStudio.TestTools.UnitTesting.TestContext");
            codeMemberProperty.HasGet = true;
            codeMemberProperty.HasSet = true;
            codeMemberProperty.Attributes = MemberAttributes.Public;

            // The getter
            codeMemberProperty.GetStatements.Add(
                new CodeMethodReturnStatement(
                new CodeFieldReferenceExpression(
                    new CodeThisReferenceExpression(), "testContext")));

            // The setter
            codeMemberProperty.SetStatements.Add(
                new CodeAssignStatement(
                    new CodeFieldReferenceExpression(
                        new CodeThisReferenceExpression(), "testContext"), new CodePropertySetValueReferenceExpression()));

            codeMemberProperty.SetStatements.Add(new CodeSnippetStatement("FeatureContext.Current[\"TestContext\"] = value;"));

            generationContext.TestClass.Members.Add(codeMemberProperty);

            generationContext.TestClass.BaseTypes.Add(new CodeTypeReference {BaseType = "FeatureBase"});
            
            base.SetTestClassInitializeMethod(generationContext);



        }
    }
}
