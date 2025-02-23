// using System;
// using System.Collections.Generic;

// namespace Sandqvist.Models
// {
//     public class FamilyTree
//     {
//         public int FamilyTreeId { get; set; }
//         public string FamilyTreeName { get; set; }
//         public DateTime BirthDate { get; set; }
//         public DateTime? DeathDate { get; set; }
//         public string Notes { get; set; }
//         public IReadOnlyCollection<Person> Parents { get; set; }
//         public IReadOnlyCollection<Person> Spouses { get; set; }
//         public IReadOnlyCollection<Person> Children { get; set; }

//         public string GetFullName()
//         {
//             if (!string.IsNullOrEmpty(Patronymic))
//             {
//                 return $"{FirstName} {Patronymic} {LastName}";
//             }
//             return $"{FirstName} {LastName}";
//         }

//         private Person() { }

//         public Person(string firstName, string lastName, Gender gender, string patronymic = null, string notes = null, IEnumerable<Person> parents = null, IEnumerable<Person> spouses = null, IEnumerable<Person> children = null)
//         {
//             if (string.IsNullOrWhiteSpace(firstName)) throw new ArgumentNullException(nameof(firstName));
//             if (string.IsNullOrWhiteSpace(lastName)) throw new ArgumentNullException(nameof(lastName));

//             FirstName = firstName;
//             LastName = lastName;
//             Gender = gender;
//             Patronymic = patronymic;
//             Notes = notes;
//             Parents = parents?.ToList().AsReadOnly() ?? new List<Person>().AsReadOnly();
//             Spouses = spouses?.ToList().AsReadOnly() ?? new List<Person>().AsReadOnly();
//             Children = children?.ToList().AsReadOnly() ?? new List<Person>().AsReadOnly();
//         }

//         public Person(string firstName, string lastName, DateTime birthDate, Gender gender, string patronymic = null, string notes = null, IEnumerable<Person> parents = null, IEnumerable<Person> spouses = null, IEnumerable<Person> children = null) : this(firstName, lastName, gender, patronymic, notes, parents, spouses, children)
//         {
//             BirthDate = ValidateDateOfBirth(birthDate);
//         }

//         public Person(string firstName, string lastName, DateTime birthDate, DateTime? deathDate, Gender gender, string patronymic = null, string notes = null, IEnumerable<Person> parents = null, IEnumerable<Person> spouses = null, IEnumerable<Person> children = null) : this(firstName, lastName, birthDate, gender, patronymic, notes, parents, spouses, children)
//         {
//             DeathDate = deathDate;
//         }

//         private static DateTime ValidateDateOfBirth(DateTime birthDate)
//         {
//             if (birthDate > DateTime.Now)
//             {
//                 throw new ArgumentException("Date of birth cannot be in the future.");
//             }
//             return birthDate;
//         }
//     }
// }