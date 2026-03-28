using System.Collections.Generic;

public enum ToolType {NONE, BUCKET, SCYTHE, SEED}
public enum SeedType {NONE, BLUE, PINK, PURPLE, RED}

public delegate void OnPlantHarvested(SeedType seed);
public delegate void OnScoreUpdated(Dictionary<SeedType, int> newScore);

public class Global
{
    
}
