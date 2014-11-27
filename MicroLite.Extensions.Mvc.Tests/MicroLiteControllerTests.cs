﻿namespace MicroLite.Extensions.Mvc.Tests
{
    using MicroLite.Extensions.Mvc;
    using Moq;
    using Xunit;

    /// <summary>
    /// Unit Tests for the <see cref="MicroLiteController"/> class.
    /// </summary>
    public class MicroLiteControllerTests
    {
        public class WhenConstructedUsingTheDefaultConstructor
        {
            private readonly MicroLiteController controller;

            public WhenConstructedUsingTheDefaultConstructor()
            {
                var mockController = new Mock<MicroLiteController>();
                mockController.CallBase = true;

                this.controller = mockController.Object;
            }

            [Fact]
            public void TheSessionIsNull()
            {
                Assert.Null(this.controller.Session);
            }
        }

        public class WhenConstructedWithAnISession
        {
            private readonly MicroLiteController controller;
#if NET_4_0
            private readonly ISession session = new Mock<ISession>().Object;
#else
            private readonly IAsyncSession session = new Mock<IAsyncSession>().Object;
#endif

            public WhenConstructedWithAnISession()
            {
                var mockController = new Mock<MicroLiteController>(this.session);
                mockController.CallBase = true;

                this.controller = mockController.Object;
            }

            [Fact]
            public void TheSessionIsSet()
            {
                Assert.Equal(this.session, this.controller.Session);
            }
        }
    }
}