using System.Collections.Generic;

namespace UniverseSimulator.Models
{
    public class Planet
    {
        public string Name { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public string Size { get; set; } = string.Empty;
        public string Atmosphere { get; set; } = string.Empty;
        public string Climate { get; set; } = string.Empty;
        public List<string> Resources { get; set; } = new List<string>();
        public string Description { get; set; } = string.Empty;
    }

    public class Species
    {
        public string Name { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public string Intelligence { get; set; } = string.Empty;
        public string Physiology { get; set; } = string.Empty;
        public string Lifespan { get; set; } = string.Empty;
        public List<string> Traits { get; set; } = new List<string>();
        public string Description { get; set; } = string.Empty;
    }

    public class TechLevel
    {
        public int Level { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public List<string> Achievements { get; set; } = new List<string>();
        public string Energy { get; set; } = string.Empty;
        public string Communication { get; set; } = string.Empty;
        public string Transportation { get; set; } = string.Empty;
        public string Population { get; set; } = string.Empty;
    }

    public class CivilizationEventCategory
    {
        public string Category { get; set; } = string.Empty;
        public List<string> Events { get; set; } = new List<string>();
    }

    public class ExtinctionReasonCategory
    {
        public string Category { get; set; } = string.Empty;
        public List<string> Reasons { get; set; } = new List<string>();
    }

    public class UniverseData
    {
        public List<Planet> Planets { get; set; } = new List<Planet>();
        public List<Species> Species { get; set; } = new List<Species>();
        public List<TechLevel> TechLevels { get; set; } = new List<TechLevel>();
        public List<CivilizationEventCategory> CivilizationEvents { get; set; } = new List<CivilizationEventCategory>();
        public List<ExtinctionReasonCategory> ExtinctionReasons { get; set; } = new List<ExtinctionReasonCategory>();
    }

    public class GeneratedCivilization
    {
        public Planet Planet { get; set; } = new Planet();
        public Species Species { get; set; } = new Species();
        public TechLevel TechLevel { get; set; } = new TechLevel();
        public string CivilizationEvent { get; set; } = string.Empty;
        public string ExtinctionReason { get; set; } = string.Empty;
        public string EventCategory { get; set; } = string.Empty;
        public string ExtinctionCategory { get; set; } = string.Empty;
    }
}