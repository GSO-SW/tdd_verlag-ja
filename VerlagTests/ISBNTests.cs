using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Verlag;

namespace VerlagTests
{
    [TestClass]
    public class ISBNTests
    {
        [TestMethod]
        public void ISBN13_KannGespeichertWerden()
        {
            //Arrange
            string iSBN13 = "9783770436163";

            //Act 
            Buch b = new Buch("Nadia", "Ich bin eure Stimme.", 12);
            b.ISBN13 = iSBN13;

            //Assert
            Assert.AreEqual(iSBN13, b.ISBN13);
        }

        [TestMethod]
        public void ISBN13_OhnePruefzifferWirdAutoVergeben()
        {
            //Arrange
            string iSBNOhnePZ = "978377043614";
            string iSBNErwartet = "9783770436149";

            //Act
            Buch b = new Buch("Nadia", "Ich bin eure Stimme.", 12);
            b.ISBN13 = iSBNOhnePZ;

            //Assert
            Assert.AreEqual(iSBNErwartet, b.ISBN13);
        }

        [TestMethod]
        public void ISBN10_KannAusISBN13ErechnetWerden()
        {
            //Arrange
            string iSBN13 = "9783770436064";
            string iSBN10 = "3770436067";

            //Act
            Buch b = new Buch("Nadia", "Ich bin eure Stimme.", 12);
            b.ISBN13 = iSBN13;

            //Assert
            Assert.AreEqual(iSBN10, b.ISBN10);
        }
    }
}
