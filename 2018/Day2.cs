using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AOC._2018
{

    class Day2
    {

        readonly string _input = @"cvfueihajytpmrdkgsxfqplbxn
        cbzueihajytnmrdkgtxfqplbwn
        cvzucihajytomrdkgstfqplqwn
        cvzueilajytomrdkgsxfqwnbwn
        cvzueihajytomrdkgsgwqphbwn
        wuzuerhajytomrdkgsxfqplbwn
        cyzueifajybomrdkgsxfqplbwn
        cvzueihajxtomrdkgpxfqplmwn
        ivzfevhajytomrdkgsxfqplbwn
        cvzueihajytomrdlgsxfqphbbn
        uvzueihajjtomrdkgsxfqpobwn
        cvzupihajytomrdkgsxfqplpwe
        cvzueihajyvomrdkgsxfqplbrl
        cczueihajytomrdkgsnfqpxbwn
        cvzueigajytdmrdkgsxyqplbwn
        cvzujihljytomrdkgsxuqplbwn
        cvzueisajytomrddgsxkqplbwn
        cvzneihajytomrdkgsgaqplbwn
        cvzueihajytomrdkgsinmplbwn
        cveueihajyromrdkgsxfqplown
        cypueihajytotrdkgzxfqplbwn
        cvzuoihajytomvdqgsxfqplbwn
        cvzuekhejytwmrdkgsxfqplbwn
        cvzseihajytomrdkgsxfqgmbwn
        cvfuhihajytomrdkgsxfqplbwi
        cvzueihujxtomrdkgsufqplbwn
        cvzueihdjytomrdogsxfqplbwh
        cvzueihdjyfohrdkgsxfqplbwn
        cvtudihajytolrdkgsxfqplbwn
        cvzueihajytymrdkgshzqplbwn
        cvzuebhajytomxdkgsxfqplbwt
        cvzulihajyxomrdkgsbfqplbwn
        cvzueihajywomrdkgsxfqplbts
        cvzueihajytouodkdsxfqplbwn
        cvzueihajytomgdkgqxfqklbwn
        cvzubihajytomvdkgsxfqplmwn
        cvhueihajyyocrdkgsxfqplbwn
        zvzueihajytourdkgsxflplbwn
        cvzbeihajytomadkgsxfoplbwn
        cvzueihajytomrdkgnxfqplbsl
        cvfueihajftkmrdkgsxfqplbwn
        cvzuexhajytomryugsxfqplbwn
        cvzueihajytomsckgsxfqalbwn
        cvzuexhajytomrdkbsxfqpluwn
        cvzueihajytbmrtkgsxwqplbwn
        cvzueihajytomrdigsxfqqlbsn
        cvzweihajytomydkgsxfmplbwn
        bvzteihajytimrdkgsxfqplbwn
        cvzueihajytpmrdkgsxfcpbbwn
        cvzueigsjltomrdkgsxfqplbwn
        cvzueihajytomrikgsxfopldwn
        cvzueihajstomrdkgsxfqplgon
        cvzueimajytomrnkxsxfqplbwn
        cvzleihagatomrdkgsxfqplbwn
        cvbueihajotomrdkgsxfqjlbwn
        cvzueihajytomrdkgsxfqppnvn
        hvzueihajytomrdkghxfkplbwn
        cvzueigajytxmrdkgsxfqplbjn
        cvzueihaaxtokrdkgsxfqplbwn
        cvzueihajyeomrdkgujfqplbwn
        cvzueiwajpoomrdkgsxfqplbwn
        cvzieidtjytomrdkgsxfqplbwn
        cvzueihalytomrakbsxfqplbwn
        wtzueihajytomrdkgsxfqplbwq
        cvzuelhaiytomrdkgsxfqplcwn
        cvzueihajytomrdkgsxfqslswd
        cvzueihajytomrykgssfqplbon
        cvzueihfjytovrdegsxfqplbwn
        cvzueihajytomldqgsxfqplbwy
        cvzleihjjytomrtkgsxfqplbwn
        cvzueihaldtomrdtgsxfqplbwn
        cvzueihajytzmrdkgsxfeplqwn
        cvzueihrjytomddkgsxfqpgbwn
        cyzulihajytokrdkgsxfqplbwn
        cvsueihajytoordfgsxfqplbwn
        fvzueyhajytomrdkgaxfqplbwn
        cczueihajytobrdkgsefqplbwn
        cvzueihajytomcdrgscfqplbwn
        cvzuexhajyvomrdkgssfqplbwn
        cvzsmihajyiomrdkgsxfqplbwn
        cvzzeihajttomrdkgsxzqplbwn
        cvzseihajytomrdkgsxfqpebvn
        cvzueihajgthmrdkgsbfqplbwn
        ruzueihajytomrdkgsxfqphbwn
        cvzueihajytofrdkgsnfrplbwn
        cvzuetdajytojrdkgsxfqplbwn
        fvzueihajytomrdkghxfqpobwn
        cvzueihsjytomrdkgsxfqglbxn
        cvzueihajytowrdkgsxfqpsbun
        cvzteihaiytomrdkfsxfqplbwn
        cvzueihajytkmrdkrsxfqplvwn
        cvzueihajyoomrdkasxfqjlbwn
        lvzurihajytkmrdkgsxfqplbwn
        cvzueihajyyomrdagsxfqelbwn
        cvfueihajytomrdkgsxfqplbbx
        cvwueihajytommdkgkxfqplbwn
        cvzucicajytomrdkgsxcqplbwn
        dvzueihahytgmrdkgsxfqplbwn
        cvzuechajytomrdkgsxfqelwwn
        cvzuekhajytomrdkgsxknplbwn
        cvtueihajytomphkgsxfqplbwn
        cvzueihabytnzrdkgsxfqplbwn
        cvzusihajytomrdkgfxfqplban
        cvfueihajytomcdfgsxfqplbwn
        mvzueihapytomrdkgsxfdplbwn
        cvzueihajytomhdkgsxmqppbwn
        jvsueihajytomrdkgsxfqplbln
        cvzujihajybomrdkgsxtqplbwn
        cvzuekhawytomrdkgsxfqplbwc
        svzueihanytomrdogsxfqplbwn
        cvzujihajytodrdkgslfqplbwn
        cvgdeihajytorrdkgsxfqplbwn
        cvzbeihajytoprdkgsxfqplbyn
        cvzueihkyytomjdkgsxfqplbwn
        cvzuelhojytomrdkgsxfqjlbwn
        evzueihajytimrdkgsxfqpsbwn
        cvzueihajydomrdkjsxfqplbjn
        ovzteihajytosrdkgsxfqplbwn
        cvzueihajyaomrdzgsxfqplbgn
        cvzuewhajmtomrdkgsufqplbwn
        cvzueihajqtomhukgsxfqplbwn
        cvzueihajytomzqkgsxfqplbwk
        cazuewhakytomrdkgsxfqplbwn
        clzueihatytomrdkgzxfqplbwn
        dvzueihajytomqdkgsxfqpnbwn
        cvzueidajdtomrdkgsxtqplbwn
        cvzueihabytowrdkgsxoqplbwn
        cvzujihwjytomrdkgsxeqplbwn
        cvtuedhajytomrdkgsxfqplbbn
        cvzueihajcgomrdkgsxfqplswn
        cvzuephajyiomrdngsxfqplbwn
        cvzueihajythmqdkgsxfqplbwf
        cvzueitajytomrdkgsxfepvbwn
        cvzueihajytomydkgsxfqplvwb
        dvzueshajytomrddgsxfqplbwn
        cvzueihajytomrdkgvxfqpwben
        cvzueihajytomrdkgvxfpplwwn
        cvzuefhajftomrdkgsxfqrlbwn
        cvzueihajytpmrvkgsxfqplbcn
        cvzueihajytohrdkgsxfqxnbwn
        cvzueihajytomrdposxfqulbwn
        cozueihajytomrpkgsxfqrlbwn
        cvzuuihaxytomrdkgsxfqplbtn
        cvzueihajytomrbzgsxyqplbwn
        cveueihajyxoqrdkgsxfqplbwn
        cvzueihajytomrkkgsxfqptbrn
        cvzuezhajatomrdkssxfqplbwn
        cpzueihajytomrdkgsxfhplbwo
        lviueihajytomrekgsxfqplbwn
        cvzueihwjytomrdkusxfyplbwn
        cvzgeihajytomwdkgsxfrplbwn
        cvzsejhzjytomrdkgsxfqplbwn
        cvzuuihajytomrdkgsxfqdlbwz
        cvzjeihajytomrdugsxftplbwn
        cvzueihaxytomrrkgsxfmplbwn
        cvzueihajgtomrdhgsxfqplwwn
        cvzulihajytomedkgsxfqplewn
        cvzueivajytomrdkmsxfqplbwc
        cvzuervajytomrdkgsxfwplbwn
        cvzuemhcjytomrdkgslfqplbwn
        cvzyerhauytomrdkgsxfqplbwn
        cvzueihaoytomrdkgsyfqplewn
        cvzueihanytomrdkgsafkplbwn
        cvzueihajvtomrdugsxfqpcbwn
        chzueihajytamrdxgsxfqplbwn
        cvzueihalytomrdsgsxfqplbln
        cvzueihajytoyaykgsxfqplbwn
        tlzueihajyeomrdkgsxfqplbwn
        cvpueihajytbmrdkgsxfxplbwn
        cvzueihajytomjdkgsxuqplkwn
        cvzueihajygomrdkgkxfqplbwg
        cvzueihajhtomrdkgbxsqplbwn
        cvzurihajytomrdkgsafqplbwx
        cdzuezhajytomrdkgsxrqplbwn
        cvbueihajytotrwkgsxfqplbwn
        cwzkeihajytomrdkgsxfqplbwh
        cvzheihajytolrikgsxfqplbwn
        cozuevhajytomrdkgkxfqplbwn
        chzueihajytomrjkgsxfqulbwn
        cvzueihkjyromrdkgsxvqplbwn
        cvzveihajytomrdkgsxpqplnwn
        cvzueihajytoirdkgsxfqihbwn
        cvoueihajytomrdkgsxfqpdawn
        pvzueihajytomrdkgnxfqplbfn
        cvzueihakytomxdkgssfqplbwn
        cvzueivajytomrdbgsxaqplbwn
        cvzueihajytokrdkgszrqplbwn
        cvzuevhajytomrdkgsxgqplbwi
        cvzueihajylomrdkgsxflplbpn
        hvzueihajytomvdkgsxfqplgwn
        cvzleihajytymrrkgsxfqplbwn
        crzueieajytomrdkgsxfqplbon
        cszueihajytomrdlgqxfqplbwn
        cvzueihacytomrdkgsxfjblbwn
        cvzreihajytomrdkgsxfqplzun
        cvzurihajytomrdkgsxiqplawn
        uvzueihajyhovrdkgsxfqplbwn
        cvzueihajyqodrdkgssfqplbwn
        cvzwiihrjytomrdkgsxfqplbwn
        cqzueihajytomrdkgjxfqplban
        cvmueihajytoordkgsxfqplbyn
        cypueihajytomrdkgzxfqplbwn
        cvzueihajykomrdkgsmfqplbtn
        cvzueidajytimrdkgsxfqpdbwn
        cvzheihajytomrdkgsxfqpfewn
        dvzueihajytumrdzgsxfqplbwn
        cvzueixajytomrdkgsvfqplgwn
        cvzuevhzjyzomrdkgsxfqplbwn
        cvyeeihajytomrdkgsxnqplbwn
        cvzueihajytomrdkggtpqplbwn
        cvzceiyajytomrdkgexfqplbwn
        cvzuelhajyyomrdkzsxfqplbwn
        cvzhzihajygomrdkgsxfqplbwn
        cvzueihwjytomrdkgsgfqplbrn
        cvzsevhajytomrdkgqxfqplbwn
        cvzueiuajytomrdkgsxfppebwn
        nvzueihajytemrdkgsxwqplbwn
        cvzueihajytocgdkgsxfqvlbwn
        cczusihajytomrdkgsxfqplbpn
        cmzueihajytomrdkbsxwqplbwn
        cvzumfdajytomrdkgsxfqplbwn
        cvzueihcjytomrdkgsxfqplbkl
        cvzueihajytomawknsxfqplbwn
        kvzueihijytomrdkgsxdqplbwn
        cdzutihajytomrdkgsxfkplbwn
        cvzufihadylomrdkgsxfqplbwn
        cvzueihajytomrgkxsxfqphbwn
        cvzuewhajyzomrdkgsxfqelbwn
        cvzueihajytomrdkgqxfqelbwc
        cvzueshajyoomrdkgsxfqflbwn
        cvzueihajyromrekgixfqplbwn
        chzugihajytomrdkgsxfqplawn
        cvzueihajytomrdkgsxfhpmbwy
        cvzueihacytodxdkgsxfqplbwn
        cvzurihajytourdkgsdfqplbwn
        cvzzeihmjytomrddgsxfqplbwn
        cvzucyhajygomrdkgsxfqplbwn
        ckzueihzjytomrdkgsxwqplbwn
        cvlueihajmtozrdkgsxfqplbwn
        cvzkeihajytomrdkgsxfqclbwc
        cvzueihajytomrdkgsxgdplbwa
        cvzueihyjytoxrdkgcxfqplbwn
        cvzueizavytomfdkgsxfqplbwn
        cvzueihajwtosrdkgsxfqllbwn
        cvzueihajytomrdaksxfqpllwn
        cvzuuihojytombdkgsxfqplbwn
        cvzuiibajytpmrdkgsxfqplbwn
        cvzueihajyuomydkgsxfqplzwn
        cvzueihajytimrmkgsxfqplfwn
        cvzueihajytomrdkgzxfqpljwo";

        //        readonly string _input = @"abcde
        //fghij
        //klmno
        //pqrst
        //fguij
        //axcye
        //wvxyz"

        int _twos, _threes;

        string[] GetLines() => _input.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries).OrderBy(s => s).Select(s=>s.Trim()).ToArray();
        static Dictionary<char, int> Group(string line) => line.GroupBy(s => s).ToDictionary(s => s.Key, s => s.Count());


        public int Task1()
        {
            string[] lines = GetLines();
            foreach (string line in lines)
            {
                var chars = Group(line);
                if (chars.Any(s => s.Value == 2)) _twos++;
                if (chars.Any(s => s.Value == 3)) _threes++;
            }
            int result = _twos * _threes;
            return result;
        }

        public string Task2()
        {
            string[] lines = GetLines();
            StringBuilder sb = new();

            for(int i = 0; i < lines.Length; i++)
            {
                string line = lines[i];
                for(int j = 0; j < lines.Length; j++)
                {
                    sb.Clear();
                    if (i == j) continue;
                    string line2 = lines[j];

                    int different = 0;
                    for(int c = 0; c < line.Length; c++)
                    {
                        if(line[c] != line2[c])
                        {
                            if(++different == 2)
                            {
                                break;
                            }
                        }
                        else
                        {
                            sb.Append(line[c]);
                        }
                    }

                    if (different == 1)
                    {
                        return sb.ToString();
                    }
                }
            }

            return "";
        }
    }
}
