using System;
using Xunit;

namespace Codenation.Challenge
{
    public class FIFACupStatsTest
    {
        [Fact]
        public void Shoud_Return_20_Itens_When_Get_Top_Players()
        {
            var cup = new FIFACupStats();
            var topPlayers = cup.First20Players();
            Assert.NotNull(topPlayers);
            Assert.Equal(20, topPlayers.Count);
        }

        [Fact]
        public void Shoud_Return_10_Itens_When_Get_Top_Players_By_Release_Clause()
        {
            var cup = new FIFACupStats();
            var topPlayers = cup.Top10PlayersByReleaseClause();
            Assert.NotNull(topPlayers);
            Assert.Equal(10, topPlayers.Count);
        }

        [Fact]
        public void Shoud_Return_10_Itens_When_Get_Top_Players_By_Age()
        {
            var cup = new FIFACupStats();
            var topPlayers = cup.Top10PlayersByAge();
            Assert.NotNull(topPlayers);
            Assert.Equal(10, topPlayers.Count);
        }

    }
}
