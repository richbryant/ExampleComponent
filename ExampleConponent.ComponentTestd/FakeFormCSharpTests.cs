using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Bunit;
using ExampleComponent.Pages;
using FluentAssertions;

namespace ExampleConponent.ComponentTestd
{
    public class FakeFormCSharpTests
    {
        [Fact]
        public void FakeFormComponentRenders()
        {
            //Arrange
            using var ctx = new TestContext();

            //Act
            var component = ctx.RenderComponent<FakeForm>();

            var fname = component.Find("#fname");
            var lname = component.Find("#lname");
            var resultText = component.Find("p");
            var heading = component.Find("h3");

            //Assert
            fname.TextContent.Should().BeSameAs(string.Empty);
            lname.TextContent.Should().BeSameAs(string.Empty);
            resultText.TextContent.Should().BeSameAs(string.Empty);
            heading.TextContent.Should().Be("FakeForm");
        }

        [Fact]
        public void FakeFormHappyPathWorks()
        {
            //Arrange
            using var ctx = new TestContext();

            //Act
            var component = ctx.RenderComponent<FakeForm>();

            var fname = component.Find("#fname");
            var lname = component.Find("#lname");
            var button = component.Find("button");
            var resultText = component.Find("p");

            fname.Change("Firstname");
            lname.Change("Lastname");
            button.Click();

            //Assert
            resultText.TextContent.Should().Be("You submitted Firstname Lastname");
        }

        [Fact]
        public void FakeFormFirstHalfCompleteDoesntSubmit()
        {
            //Arrange
            using var ctx = new TestContext();

            //Act
            var component = ctx.RenderComponent<FakeForm>();

            var fname = component.Find("#fname");
            var lname = component.Find("#lname");
            var button = component.Find("button");
            var resultText = component.Find("p");

            fname.Change("Firstname");
            button.Click();

            //Assert
            resultText.TextContent.Should().BeSameAs(string.Empty);
        }

        [Fact]
        public void FakeFormSecondHalfCompleteDoesntSubmit()
        {
            //Arrange
            using var ctx = new TestContext();

            //Act
            var component = ctx.RenderComponent<FakeForm>();

            var fname = component.Find("#fname");
            var lname = component.Find("#lname");
            var button = component.Find("button");
            var resultText = component.Find("p");

            lname.Change("Lastname");
            button.Click();

            //Assert
            resultText.TextContent.Should().BeSameAs(string.Empty);
        }
    }
}
