using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public record ProductResultDTO
    {
        #region Record Info
        /*In ASP.NET, particularly from C# 9.0 onwards, a record is a type introduced to simplify the creation of immutable data objects. Unlike traditional classes, records focus on the immutability and comparison of data, making them particularly suitable for situations where you need to store and pass around sets of values without the risk of unintended changes.

Here are the most important features of records and their typical use cases:

1. Immutability
Records are designed to be immutable by default, meaning once you create an instance of a record, you can't modify its properties. This immutability is achieved by defining the record’s properties as init-only, which allows values to be set during initialization but not altered afterwards.
You can still create a "mutable" record if needed by using record class, though this goes against the primary design intent.
2. Value-Based Equality
Unlike classes, which use reference equality by default, records use value-based equality. Two record instances with identical property values are considered equal.
This is especially useful when you need to compare objects based on their contents rather than their references, making records suitable for data-centric applications where equality matters.
3. Concise Syntax
Records offer a concise syntax for defining data objects. You can create a record with a single line:
csharp
Copy code
public record Product(string Name, decimal Price);
This provides auto-generated ToString, Equals, and GetHashCode implementations, along with a deconstructor, making it very efficient to work with.
4. With-Expression Support
Records support the with keyword, which creates a shallow copy of the record with some properties modified, without affecting the original.
Example:
csharp
Copy code
var product = new Product("Laptop", 1000M);
var discountedProduct = product with { Price = 900M };
This feature enables functional-style data transformations, making it easier to work with immutable data in scenarios where modifications need to be made without altering the original instance.
5. Deconstruction Support
Records can be deconstructed into their individual components:
csharp
Copy code
var product = new Product("Laptop", 1000M);
var (name, price) = product;
This feature allows records to seamlessly integrate with deconstruction patterns, improving readability and compatibility with tuple-like operations.
6. Inheritance Support
Records support inheritance, though they are better suited for immutable data transfer objects (DTOs) or entities rather than deep inheritance hierarchies. For example, you can define a base record and derive from it if needed.
Use Cases for Records
Data Transfer Objects (DTOs):

Records are ideal for defining DTOs used in APIs and other data-sharing layers since they’re lightweight, immutable, and comparable by value.
Example:
csharp
Copy code
public record UserDto(string Name, string Email);
Read-Only Models in CQRS:

In Command Query Responsibility Segregation (CQRS) patterns, records can serve as immutable read models, representing query results or data snapshots that are not meant to be modified after creation.
Event Sourcing and Domain Events:

For event-driven architectures, records can be used to represent domain events since they typically store data about a single event that should not change.
Configuration Objects:

Immutable configuration data, such as settings for an application, can be represented using records to ensure they remain unchanged once loaded.
Lightweight Entity Representation in Tests:

In testing scenarios, records can be used to quickly create lightweight representations of entities for validation and comparison.
Records are a powerful feature in ASP.NET development, especially when designing clean, immutable data structures. They enhance code readability, maintainability, and enforce immutability by default, making them ideal for functional programming patterns and modern C# coding practices.*/
        #endregion


        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string PictureUrl { get; set; }

        public decimal Price { get; set; }

        public string TypeName { get; set; }

        public string BrandName { get; set; }
    }
}
