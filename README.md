# TheNoobs.ValueObjects.ExternalId

A lightweight and opinionated .NET library that implements **Value Objects** for external identifiers, using **Hashids.net** as the generation engine.

## Why use ExternalId as a Value Object?

Using raw strings or GUIDs for external IDs exposes your domain to **Primitive Obsession**. This library solves this by offering:

* **Type Safety:** Prevents accidental swapping of different ID types (e.g., passing an `OrderId` where a `CustomerId` is expected).
* **Immutability:** Once created, the identifier cannot be changed, ensuring object integrity throughout its lifecycle.
* **Smart Obfuscation:** Powered by Hashids, your internal (sequential) IDs are not directly exposed, making scraping or enumeration attacks significantly harder.
* **Clear Semantics:** The use of prefixes makes identifiers human-readable and easily identifiable across external systems (e.g., `user_3p98Xz`).

## Installation

Install via NuGet Package Manager:

```bash
dotnet add package TheNoobs.ValueObjects.ExternalId

```

## How to Use

### 1. Defining your Domain ID

Create a class that inherits from `ExternalId`. The implementation requires two constructors to cover both **generation** and **hydration** scenarios:

```csharp
public class StubId : ExternalId
{
    // Constructor for hydration (e.g., from Database or external API)
    // It intentionally skips structure validation to allow flexibility when loading existing data.
    public StubId(string value) : base(value)
    {
    }

    // Constructor for generating new IDs
    // Defines the length (e.g., 30 characters) and the identifying prefix.
    public StubId() : base(30, "stub_")
    {
    }
}

```

### 2. Practical Examples

```csharp
// Generating a new unique ID using the Hashids engine
var newId = new StubId();
Console.WriteLine(newId.Value); // Output: stub_... (generated id)

// Hydrating an object from a known string
var existingId = new StubId("stub_abc123");

// Equality comparison (Value-based)
if (newId == existingId)
{
    // ...
}

```

## Design and Persistence

This implementation was designed to be ORM-friendly. The constructor that accepts a `string` allows **Entity Framework** or **Dapper** to reconstruct the object from the database without triggering the hash generation logic, preserving the original value transparently.

## License

This project is licensed under the **MIT License**.

---

Developed with love <3 by [The Noobs](https://github.com/thenoobsbr).
