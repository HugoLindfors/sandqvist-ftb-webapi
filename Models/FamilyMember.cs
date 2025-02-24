using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Sandqvist.Models
{
    public enum Gender { Male, Female, Other, Unknown }

    public class FamilyMember
    {
        public static string GenerateRandomId()
        {
            return "r68UMYBrXQz";
        }

        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string FamilyName { get; set; }

        [Required]
        public string FirstName { get; set; }

        public Gender Gender { get; set; }
        public DateTime? BirthDate { get; set; }
        public DateTime? DeathDate { get; set; }
        public string? Notes { get; set; }
        public IReadOnlyCollection<FamilyMember>? Parents { get; set; }
        public IReadOnlyCollection<FamilyMember>? Spouses { get; set; }
        public IReadOnlyCollection<FamilyMember>? Children { get; set; }

        public string GetFullName()
        {
            return $"{FirstName} {FamilyName}";
        }

        public FamilyMember(int id, string familyName, string firstName, Gender gender, string? notes = null, IEnumerable<FamilyMember>? parents = null, IEnumerable<FamilyMember>? spouses = null, IEnumerable<FamilyMember>? children = null)
        {

            if (string.IsNullOrWhiteSpace(firstName)) throw new ArgumentNullException(nameof(firstName));
            if (string.IsNullOrWhiteSpace(familyName)) throw new ArgumentNullException(nameof(familyName));

            Id = id;
            FirstName = firstName;
            FamilyName = familyName;
            Gender = gender;
            Notes = notes;
            Parents = parents?.ToList().AsReadOnly() ?? new List<FamilyMember>().AsReadOnly();
            Spouses = spouses?.ToList().AsReadOnly() ?? new List<FamilyMember>().AsReadOnly();
            Children = children?.ToList().AsReadOnly() ?? new List<FamilyMember>().AsReadOnly();
        }

        public FamilyMember(int id, string familyName, string firstName, DateTime birthDate, Gender gender, string? notes = null, IEnumerable<FamilyMember>? parents = null, IEnumerable<FamilyMember>? spouses = null, IEnumerable<FamilyMember>? children = null) : this(id, firstName, familyName, gender, notes, parents, spouses, children)
        {
            BirthDate = ValidateDateOfBirth(birthDate);
        }

        public FamilyMember(int id, string familyName, string firstName, Gender gender, DateTime birthDate, DateTime? deathDate, string? notes = null, IEnumerable<FamilyMember>? parents = null, IEnumerable<FamilyMember>? spouses = null, IEnumerable<FamilyMember>? children = null) : this(id, firstName, familyName, birthDate, gender, notes, parents, spouses, children)
        {
            DeathDate = deathDate;
        }

        private static DateTime ValidateDateOfBirth(DateTime birthDate)
        {
            if (birthDate > DateTime.Now)
            {
                throw new ArgumentException("Date of birth cannot be in the future.");
            }
            return birthDate;
        }
    }
}