using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Verlag;

namespace VerlagTests
{
	[TestClass]
	public class BuchTests
	{
		[TestMethod]
		public void Buch_KannErstelltWerden()
		{
			//Arrange
			string autor = "J.K. Rowling";
			string titel = "Harry Potter und der Gefangene von Askaban";
			int auflage = 1;

			//Act 
			Buch b = new Buch(autor, titel, 12, auflage);

			//Assert
			Assert.AreEqual(autor, b.Autor);
			Assert.AreEqual(titel, b.Titel);
			Assert.AreEqual(auflage, b.Auflage);
		}

		[TestMethod]
		public void Buch_KeineAuflageEntsprichtErsterAuflage()
		{
			//Arrange

			//Act 
			Buch b = new Buch("autor", "titel", 12);

			//Assert
			Assert.AreEqual(1, b.Auflage);
		}

		[TestMethod]
		public void Autor_DarfVeraendertWerden()
		{
			//Arrange
			string autor = "Abdullah";
			string autorNeu = "Thomas";

			//Act
			Buch b = new Buch(autor, "titel", 12);
			b.Autor = autorNeu;

			//Assert
			Assert.AreEqual(autorNeu, b.Autor);

		}

		[TestMethod]
		public void Auflage_DarfVeraendertWerden()
		{
			//Arrange
			int auflage = 15;
			int auflageNeu = 42;

			//Act
			Buch b = new Buch("autor", "titel", 12, auflage);
			b.Auflage = auflageNeu;

			//Assert
			Assert.AreEqual(auflageNeu, b.Auflage);

		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentOutOfRangeException))]
		public void Buch_AuflageDarfNichtZuKleinSein()
		{
			//Arrange
			int auflage = 0;

			//Act
			Buch b = new Buch("autor", "titel", 12, auflage);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentOutOfRangeException))]
		public void Auflage_DarfNichtZuKleinSein()
		{
            //Act
            Buch b = new Buch("autor", "titel", 12);
            int auflageNeu = 0;
            b.Auflage = auflageNeu;
		}

		// DataRow: https://learn.microsoft.com/en-us/dotnet/core/testing/unit-testing-with-mstest#add-more-features
		[TestMethod]
		[DataRow("")]
		[DataRow("Ale#x")]
		[DataRow(";Max")]
		[DataRow("§Nadia")]
		[DataRow("%DC")]
		[ExpectedException(typeof(ArgumentException))]
		public void Autor_NurSinnvolleEingabenErlaubt(string nichtsinvolleEingabe)
		{
			//Act
			Buch b = new Buch(nichtsinvolleEingabe, "titel", 12);
		}
	}
}
