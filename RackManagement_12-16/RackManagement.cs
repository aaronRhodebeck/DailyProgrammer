namespace RackManagement
{
    
    public class ScrabbleRack
    {
        private const string PossibleTiles = "abcdefghijklmnopqrstuvwxyz?";
        public string Tiles { get; set; }
        private int[] TileFrequency { get; set; }
        
        public ScrabbleRack(string tiles)
        {
            this.Tiles = tiles.ToLower();
            this.TileFrequency = SortTiles(tiles);
        }

        private int[] SortTiles(string tiles)
        {
            var tileFrequency = new int[PossibleTiles.Length];
            foreach (var tile in tiles)
            {
                tileFrequency[PossibleTiles.IndexOf(tile)]++;
            }
            return tileFrequency;
        }

        public bool CanMakeWord(string word)
        {
            int wildcardsNeeded = 0;        
            var tilesNeeded = SortTiles(word);

            for (int i = 0; i < tilesNeeded.Length; i++)
            {
                if (tilesNeeded[i] > TileFrequency[i])
                {
                    wildcardsNeeded += tilesNeeded[i] - TileFrequency[i];
                }
                
                if (wildcardsNeeded > TileFrequency[TileFrequency.Length -1])
                {
                    return false;
                }
            }
            
            return true;
        }

/*        public string LongestWord(string[] wordList)
        {

        }
*/    }
}