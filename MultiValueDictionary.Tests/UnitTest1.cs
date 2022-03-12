using NUnit.Framework;
using System.Collections.Generic;

namespace MultiValueDictionary.Tests
{
    public class DictionaryTests
    {       
        [Test]
        public void Add()
        {
            var dict = new DictionaryService();

            var response = dict.Add("foo", "bar");
            Assert.AreEqual(ReturnMessages.Added, response.Message);

            response = dict.Add("foo", "baz");
            Assert.AreEqual(ReturnMessages.Added, response.Message);

            response = dict.Add("foo", "bar");
            Assert.AreEqual(ReturnMessages.MemberAlreadyExists, response.Message);
        }

        [Test]
        public void Keys()
        {
            var dict = new DictionaryService();

            var response = dict.Add("foo", "bar");
            Assert.AreEqual(ReturnMessages.Added, response.Message);

            response = dict.Add("baz", "bang");
            Assert.AreEqual(ReturnMessages.Added, response.Message);

            var expectedList = new List<string>();
            expectedList.Add("foo");
            expectedList.Add("baz");
            response = dict.Keys();
            Assert.AreEqual(expectedList, response.Result);
        }

        [Test]
        public void Members()
        {            
            var dict = new DictionaryService();

            dict.Add("foo", "bar");
            dict.Add("foo", "baz");

            var expectedList = new List<string>();
            expectedList.Add("bar");
            expectedList.Add("baz");
            var response = dict.Members("foo");
            Assert.AreEqual(expectedList, response.Result);
                                   
            response = dict.Members("bad");
            Assert.AreEqual(ReturnMessages.KeyNotExist, response.Message);
        }

        [Test]
        public void Remove()
        {
            var dict = new DictionaryService();

            dict.Add("foo", "bar");
            dict.Add("foo", "baz");
           
            var response = dict.Remove("foo", "bar");
            Assert.AreEqual(ReturnMessages.Removed, response.Message);

            response = dict.Remove("foo", "bar");
            Assert.AreEqual(ReturnMessages.MemberNotExist, response.Message);

            var expectedList = new List<string>();
            expectedList.Add("foo");
            response = dict.Keys();
            Assert.AreEqual(expectedList, response.Result);

            response = dict.Remove("foo", "baz");
            Assert.AreEqual(ReturnMessages.Removed, response.Message);

            response = dict.Keys();
            Assert.AreEqual(ReturnMessages.EmptySet, response.Message);

            response = dict.Remove("boom", "pow");
            Assert.AreEqual(ReturnMessages.KeyNotExist, response.Message);
        }

        [Test]
        public void RemoveAll()
        {
            var dict = new DictionaryService();

            dict.Add("foo", "bar");
            dict.Add("foo", "baz");

            var response = dict.RemoveAll("foo");
            Assert.AreEqual(ReturnMessages.Removed, response.Message);

            response = dict.Keys();
            Assert.AreEqual(ReturnMessages.EmptySet, response.Message);

            response = dict.RemoveAll("foo");
            Assert.AreEqual(ReturnMessages.KeyNotExist, response.Message);
        }

        [Test]
        public void Clear()
        {
            var dict = new DictionaryService();

            dict.Add("foo", "bar");
            dict.Add("bang", "zip");

            var response = dict.Clear();
            Assert.AreEqual(ReturnMessages.Cleared, response.Message);

            response = dict.Keys();
            Assert.AreEqual(ReturnMessages.EmptySet, response.Message);

            response = dict.Clear();
            Assert.AreEqual(ReturnMessages.Cleared, response.Message);

            response = dict.Keys();
            Assert.AreEqual(ReturnMessages.EmptySet, response.Message);
        }

        [Test]
        public void KeyExists()
        {
            var dict = new DictionaryService();

            var response = dict.KeyExists("foo");
            Assert.AreEqual(ReturnMessages.False, response.Message);

            dict.Add("foo", "bar");

            response = dict.KeyExists("foo");
            Assert.AreEqual(ReturnMessages.True, response.Message);
        }

        [Test]
        public void MemberExists()
        {
            var dict = new DictionaryService();

            var response = dict.MemberExists("foo", "bar");
            Assert.AreEqual(ReturnMessages.False, response.Message);

            dict.Add("foo", "bar");

            response = dict.MemberExists("foo", "bar");
            Assert.AreEqual(ReturnMessages.True, response.Message);

            response = dict.MemberExists("foo", "baz");
            Assert.AreEqual(ReturnMessages.False, response.Message);
        }

        [Test]
        public void AllMembers()
        {
            var dict = new DictionaryService();

            var response = dict.AllMembers();
            Assert.AreEqual(ReturnMessages.EmptySet, response.Message);

            dict.Add("foo", "bar");
            dict.Add("foo", "baz");

            var expectedList = new List<string>();
            expectedList.Add("bar");
            expectedList.Add("baz");
            response = dict.AllMembers();
            Assert.AreEqual(expectedList, response.Result);

            dict.Add("bang", "bar");
            dict.Add("bang", "baz");

            expectedList = new List<string>();
            expectedList.Add("bar");
            expectedList.Add("baz");
            expectedList.Add("bar");
            expectedList.Add("baz");
            response = dict.AllMembers();
            Assert.AreEqual(expectedList, response.Result);
        }

        [Test]
        public void Items()
        {
            var dict = new DictionaryService();

            var response = dict.Items();
            Assert.AreEqual(ReturnMessages.EmptySet, response.Message);

            dict.Add("foo", "bar");
            dict.Add("foo", "baz");

            var expectedList = new List<string>();
            expectedList.Add("foo: bar");
            expectedList.Add("foo: baz");
            response = dict.Items();
            Assert.AreEqual(expectedList, response.Result);

            dict.Add("bang", "bar");
            dict.Add("bang", "baz");

            expectedList = new List<string>();
            expectedList.Add("foo: bar");
            expectedList.Add("foo: baz");
            expectedList.Add("bang: bar");
            expectedList.Add("bang: baz");
            response = dict.Items();
            Assert.AreEqual(expectedList, response.Result);
        }
    }
}