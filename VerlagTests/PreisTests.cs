using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Verlag;

namespace VerlagTests
{
    [TestClass]
    public class PreisTests
    {
        [TestMethod]
        public void Buch_PreisMussGespeichertWerden()
        {
            //Arrange
            double preis = 15.00;

            //Act
            Buch b = new Buch("Autor", "titel", preis);

            //Assert
            Assert.AreEqual(preis, b.Preis);
        }

        [TestMethod]
        public void Preis_DarfGeaendertWerden()
        {
            //Arrange
            double preis = 10;
            double neuPreis = 12;

            //Act
            Buch b = new Buch("Autor", "Titel", preis);
            b.Preis = neuPreis;

            //Assert
            Assert.AreEqual(neuPreis, b.Preis);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Buch_PreisDarfNichtNegativSein()
        {
            //Arrange
            double preis = -10;

            //Act
            Buch b = new Buch("Autor", "Titel", preis);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Preis_DarfNichtNegativSein()
        {
            //Arrange
            double preis = 10;
            double neuPreis = -5;

            //Act
            Buch b = new Buch("Autor", "Titel", preis);
            b.Preis = neuPreis;
        }
    }
}
