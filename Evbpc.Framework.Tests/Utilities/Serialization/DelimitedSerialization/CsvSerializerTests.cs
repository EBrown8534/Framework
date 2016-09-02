using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Evbpc.Framework.Utilities.Serialization.DelimitedSerialization;
using System.Collections.Generic;

namespace Evbpc.Framework.Tests.Utilities.Serialization.DelimitedSerialization
{
    [TestClass]
    public class CsvSerializerTests
    {
        class Config
        {
            public string[] Names { get; set; } = { "Mark", "Ralph", "Shawn" };
            public int[] Positions { get; set; } = { 1, 0, 3 };
            public string InvalidName { get; set; } = "Mark,";
        }

        class TestObject1
        {
            [DelimitedColumn]
            public string Name { get; set; }
        }

        [TestMethod, TestCategory("Csv Serializer Tests")]
        public void SerializeOneProperty()
        {
            var expected = "Name";
            var input = new List<TestObject1>();
            var config = new Config();

            for (int i = 0; i < config.Names.Length; i++)
            {
                input.Add(new TestObject1 { Name = config.Names[i] });
                expected += Environment.NewLine + config.Names[i];
            }

            var csvSerializer = DelimitedSerializer.CsvSerializer;
            var actual = csvSerializer.Serialize(input);

            Assert.AreEqual(expected, actual);
        }

        class TestObject2
        {
            [DelimitedColumn(Name = "n")]
            public string Name { get; set; }
        }

        [TestMethod, TestCategory("Csv Serializer Tests")]
        public void SerializeOnePropertyWithName()
        {
            var expected = "n";
            var input = new List<TestObject2>();
            var config = new Config();

            for (int i = 0; i < config.Names.Length; i++)
            {
                input.Add(new TestObject2 { Name = config.Names[i] });
                expected += Environment.NewLine + config.Names[i];
            }

            var csvSerializer = DelimitedSerializer.CsvSerializer;
            var actual = csvSerializer.Serialize(input);

            Assert.AreEqual(expected, actual);
        }

        class TestObject3
        {
            [DelimitedColumn]
            public string Name { get; set; }

            [DelimitedColumn]
            public int Position { get; set; }
        }

        [TestMethod, TestCategory("Csv Serializer Tests")]
        public void SerializeTwoProperties()
        {
            var expected = "Name,Position";
            var input = new List<TestObject3>();
            var config = new Config();

            for (int i = 0; i < config.Names.Length; i++)
            {
                input.Add(new TestObject3 { Name = config.Names[i], Position = config.Positions[i] });
                expected += Environment.NewLine + config.Names[i] + "," + config.Positions[i];
            }

            var csvSerializer = DelimitedSerializer.CsvSerializer;
            var actual = csvSerializer.Serialize(input);

            Assert.AreEqual(expected, actual);
        }

        class TestObject4
        {
            [DelimitedColumn(Order = 1)]
            public string Name { get; set; }

            [DelimitedColumn(Order = 0)]
            public int Position { get; set; }
        }

        [TestMethod, TestCategory("Csv Serializer Tests")]
        public void SerializeTwoPropertiesWithOrder()
        {
            var expected = "Position,Name";
            var input = new List<TestObject4>();
            var config = new Config();

            for (int i = 0; i < config.Names.Length; i++)
            {
                input.Add(new TestObject4 { Name = config.Names[i], Position = config.Positions[i] });
                expected += Environment.NewLine + config.Positions[i] + "," + config.Names[i];
            }

            var csvSerializer = DelimitedSerializer.CsvSerializer;
            var actual = csvSerializer.Serialize(input);

            Assert.AreEqual(expected, actual);
        }

        class TestObject5
        {
            [DelimitedColumn(Name = "n")]
            public string Name { get; set; }

            [DelimitedColumn(Name = "p")]
            public int Position { get; set; }
        }

        [TestMethod, TestCategory("Csv Serializer Tests")]
        public void SerializeTwoPropertiesWithName()
        {
            var expected = "n,p";
            var input = new List<TestObject5>();
            var config = new Config();

            for (int i = 0; i < config.Names.Length; i++)
            {
                input.Add(new TestObject5 { Name = config.Names[i], Position = config.Positions[i] });
                expected += Environment.NewLine + config.Names[i] + "," + config.Positions[i];
            }

            var csvSerializer = DelimitedSerializer.CsvSerializer;
            var actual = csvSerializer.Serialize(input);

            Assert.AreEqual(expected, actual);
        }

        class TestObject6
        {
            [DelimitedColumn(Name = "n", Order = 1)]
            public string Name { get; set; }

            [DelimitedColumn(Name = "p", Order = 0)]
            public int Position { get; set; }
        }

        [TestMethod, TestCategory("Csv Serializer Tests")]
        public void SerializeTwoPropertiesWithNameAndOrder()
        {
            var expected = "p,n";
            var input = new List<TestObject6>();
            var config = new Config();

            for (int i = 0; i < config.Names.Length; i++)
            {
                input.Add(new TestObject6 { Name = config.Names[i], Position = config.Positions[i] });
                expected += Environment.NewLine + config.Positions[i] + "," + config.Names[i];
            }

            var csvSerializer = DelimitedSerializer.CsvSerializer;
            var actual = csvSerializer.Serialize(input);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod, TestCategory("Csv Serializer Tests")]
        public void SerializeWithInvalidValue()
        {
            string expected = "Name";
            var input = new List<TestObject1>();
            var config = new Config();

            for (int i = 0; i < config.Names.Length; i++)
            {
                if (i == 0)
                {
                    input.Add(new TestObject1 { Name = config.InvalidName });
                    expected += Environment.NewLine + config.InvalidName.Replace(",", "\\u002C");
                }
                else
                {
                    input.Add(new TestObject1 { Name = config.Names[i] });
                    expected += Environment.NewLine + config.Names[i];
                }
            }

            var csvSerializer = DelimitedSerializer.CsvSerializer;
            var actual = csvSerializer.Serialize(input);

            Assert.AreEqual(expected, actual);
        }
    }
}
