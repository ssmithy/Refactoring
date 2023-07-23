namespace Refactoring.Domain.Tests
{
    public class Tests
    {

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void MyEntity_InitialisesCorrectly()
        {
            //act
            var e = CreateMyEntity();

            //assert
            Assert.That(e, Is.Not.Null);
            Assert.That(e.StringValue, Is.EqualTo(myEntityDefaultStringValue));
        }

        [Test]
        public void MyEntity_DoesAThing()
        {
            //arrange
            var e = CreateMyEntity();

            //act
            //assert
            Assert.DoesNotThrow(() => e.InvalidateThisObject());
        }

        [Test]
        public void MyEntity_Validate_IsValid()
        {
            //arrange
            var e = CreateMyEntity();

            //act
            var validationResults = e.Validate(new System.ComponentModel.DataAnnotations.ValidationContext(this));

            //assert
            Assert.That(() => { return validationResults.Count() == 0; });
        }

        [Test]
        public void MyEntity_Validate_IsInvalid()
        {
            //arrange
            var e = CreateMyEntity();

            //act
            e.InvalidateThisObject();

            var validationResults = e.Validate(new System.ComponentModel.DataAnnotations.ValidationContext(this));

            //assert
            Assert.That(() => { return validationResults.Count() > 0; });
        }


        string myEntityDefaultStringValue = "Default Value";

        MyEntity CreateMyEntity()
        {
            return new MyEntity(myEntityDefaultStringValue);
        }

    }
}