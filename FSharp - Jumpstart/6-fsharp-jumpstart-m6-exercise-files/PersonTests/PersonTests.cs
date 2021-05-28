using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Module6;
using NUnit.Framework;

namespace PersonTests
{
    public class PersonTests
    {
        // Accessing interface members from C#:
        [Test]
        public void Person_Fullname_Is_Correctly_Built()
        {
            var expected = "James Mason";
            var sut = new PersonFromInterface("James", "Mason");
            var actual = (sut as IPerson).Fullname;
            Assert.AreEqual(expected, actual);
        }
    }

    public class ContactPersonTests
    {
        // Creating and accessing Discriminated Unions from C#:
        [Test]
        public void We_can_construct_a_ContactPerson_with_a_Phone_Number_Preferred_Contact()
        {
            var expectedCode = "0123";
            var expectedNumber = "45678";
            var contactDetails = Contact.NewPhoneNumber(expectedCode, expectedNumber);
            var sut = new ContactPerson("James", "Mason", contactDetails);
            var actualCode = (sut.PreferredContact as Contact.PhoneNumber).AreaCode;
            var actualNumber = (sut.PreferredContact as Contact.PhoneNumber).Number;
            Assert.AreEqual(expectedCode, actualCode);
            Assert.AreEqual(expectedNumber, actualNumber);
        }    
    }
}
