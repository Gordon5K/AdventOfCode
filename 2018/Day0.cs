using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace AOC._2018
{
    class Day0
    {
        readonly string _input = @"a: b160051e-b299-4683-9850-53c45b6ed153: [1,False,1H - BT]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: b160051e-b299-4683-9850-53c45b6ed153: [1,False,1H - BT]
b: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
result: -1
a: 582c4a2f-8eba-4e35-8bad-dabdb7fd89ef: [1,False,1H - ISLE]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 95dad1c9-bd58-464e-a03a-d9c033a00a0e: [1,False,1H - ISLE]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 9a33a883-ddfd-4157-baff-2d6a71d72b29: [1,False,1H - ISLE]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: a92b05bd-556c-4404-9fb4-307da22780c0: [1,False,1H - JE/GY]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 68008bf3-01d4-4543-8499-bfe23592dcdb: [1,False,1H - ROI 72]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 79e1cf25-85cc-4d12-a524-7e5e042a899e: [1,False,1H - ROI 72]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 820a9125-2b1e-4354-9fc1-1e6f14786023: [1,False,1H - ROI 72]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 9937da0c-b878-4ba1-b0de-0eb3b141e0f3: [1,False,1H - ROI 72]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: cc25ae86-2f23-4ce5-b4bd-4cef600d5b62: [1,False,1H - ROI 72]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: f523fa94-a1d1-4aa7-aeb0-0500ef6dbe76: [1,False,1H - ROI 72]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 036958d5-1780-4c90-89b9-c5350d69c2f6: [1,False,1H - UK MAIN]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 04cc826d-00cb-47e7-a5de-5017fb2637a5: [1,False,1H - UK MAIN]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 04d783d2-faa0-4721-92de-dc3a3b26dd35: [1,False,1H - UK MAIN]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 0585b364-aa01-4b00-badf-a0720d1b83c1: [1,False,1H - UK MAIN]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 08457485-e7c3-472f-b2cb-d3d4dc1f8c8c: [1,False,1H - UK MAIN]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 0bee2430-00d6-41ba-a814-21556cfd2290: [1,False,1H - UK MAIN]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 0ca7cb91-3f00-4fae-84b4-71d37726ace3: [1,False,1H - UK MAIN]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 0fcad0df-2db3-44cb-85f7-d52c2f12679f: [1,False,1H - UK MAIN]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 123f9650-3d06-4815-894f-a141ca690f2b: [1,False,1H - UK MAIN]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 12be5088-5bae-4732-b94a-9fcbe5a26828: [1,False,1H - UK MAIN]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 12cd7079-83e4-421c-8264-83dba2d3bdfd: [1,False,1H - UK MAIN]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 13ac1958-21db-4377-8cfb-45a3dc4bff9d: [1,False,1H - UK MAIN]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 148c84d8-241a-4456-8b51-aaebf0e36915: [1,False,1H - UK MAIN]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 14c85aa2-83bf-4987-aa00-741acf91c549: [1,False,1H - UK MAIN]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 17929f27-30cb-485e-b5b1-aa9fbc704122: [1,False,1H - UK MAIN]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 17f82642-46bc-4caf-bac7-7645863e3cad: [1,False,1H - UK MAIN]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 18160013-90a9-4bae-a3e2-08d09a77ac9d: [1,False,1H - UK MAIN]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 20fe4553-416e-4a99-92f7-d583bb2b862f: [1,False,1H - UK MAIN]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 22ac94e2-28e2-4a37-a28b-1a64c38db2c6: [1,False,1H - UK MAIN]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 25c5bf7e-affe-42f8-a4e2-f1d4edd37216: [1,False,1H - UK MAIN]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 2a606307-f26f-4fc3-8684-706916031656: [1,False,1H - UK MAIN]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 2aac8d1d-d514-4469-b8cf-c9c03b76a3fd: [1,False,1H - UK MAIN]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 2c1c7e67-af72-44fe-8240-3e603536171d: [1,False,1H - UK MAIN]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 2cbc9eee-a359-4d29-a6ca-a99cded590ca: [1,False,1H - UK MAIN]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 2ccdc8eb-5305-4d6d-a58b-b942bfa149e0: [1,False,1H - UK MAIN]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 2d000e4f-865a-4dc2-aee5-1e6b39e0cebd: [1,False,1H - UK MAIN]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 2d0921bd-e2ca-40cd-8643-28fd9057ad58: [1,False,1H - UK MAIN]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 2d25fcd4-ede6-4a29-a985-af14efe995d9: [1,False,1H - UK MAIN]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 2d66ca09-5b14-45c1-b2c4-c1fa0f5745c5: [1,False,1H - UK MAIN]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 2f9ec3e0-88cf-4617-bca8-0d75d4226e34: [1,False,1H - UK MAIN]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 31f34478-0801-47c2-aab5-034e946619f8: [1,False,1H - UK MAIN]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 32c4ba11-910d-424a-9b94-cb23bc328d70: [1,False,1H - UK MAIN]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 33653de0-c047-44ec-a8ce-554ba3c9d255: [1,False,1H - UK MAIN]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 340e4120-59dd-461d-a26f-840ef5c6850a: [1,False,1H - UK MAIN]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 34f180c9-f054-4c20-af13-1531bb6457ff: [1,False,1H - UK MAIN]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 36d6e556-3d50-465a-95fd-497a01d19e2a: [1,False,1H - UK MAIN]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 39a42cad-9cb1-4b26-b434-cd4b5f203990: [1,False,1H - UK MAIN]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 3a18337f-bda7-4466-9458-49b524ab97d3: [1,False,1H - UK MAIN]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 3fe4a51e-6124-401c-9424-333b89985a8c: [1,False,1H - UK MAIN]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 4024693f-0f49-4c86-bcbc-7a3f5549009d: [1,False,1H - UK MAIN]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 4367a8da-cb39-4528-8f0c-8fdf22934b98: [1,False,1H - UK MAIN]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 441e7fe5-4664-4816-a129-e17d92d048db: [1,False,1H - UK MAIN]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 450101ce-6ba9-4b77-a61f-fa38bade6331: [1,False,1H - UK MAIN]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 460bb83b-491d-4de3-b436-807e62ab79f6: [1,False,1H - UK MAIN]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 49cb64b3-3757-409b-b0cb-38560ba787d7: [1,False,1H - UK MAIN]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 4a22a8b8-9ddb-4b97-b424-cbd225c0fbcb: [1,False,1H - UK MAIN]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 4c130024-ec5a-4b9f-ad63-3ee1352cdece: [1,False,1H - UK MAIN]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 4cadb38e-5340-4257-bb46-b079c5f340d7: [1,False,1H - UK MAIN]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 4e399198-b715-430f-a886-51f1cbf8a841: [1,False,1H - UK MAIN]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 4e7121c8-ba53-4ce8-a6e9-c18fee0a957c: [1,False,1H - UK MAIN]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 4fc42641-2c13-4d28-b258-a0f78f247762: [1,False,1H - UK MAIN]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 513de93d-a3e9-4eba-bdf4-e327afba0015: [1,False,1H - UK MAIN]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 51453c3d-a782-45b9-bdd6-054ed4e4dbe1: [1,False,1H - UK MAIN]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 5195091e-4dc7-4ff7-9223-6302bb4c56c7: [1,False,1H - UK MAIN]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 54970c73-f0a0-49ad-9905-bb9a62ff02e1: [1,False,1H - UK MAIN]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 551b1561-7d05-4bbc-a8ed-f15445f02dda: [1,False,1H - UK MAIN]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 55705a0d-2b71-4aef-b947-d3994c6bd878: [1,False,1H - UK MAIN]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 5752e0d4-d608-4087-8182-44ae28f27eaf: [1,False,1H - UK MAIN]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 5d00e25a-6c98-4dd1-8a2d-948d13361a4d: [1,False,1H - UK MAIN]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 5e9d20be-3fec-4d63-b12d-52128c8188a6: [1,False,1H - UK MAIN]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 60670a39-6c14-4e3a-9775-97b9b1b1c79e: [1,False,1H - UK MAIN]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 62130ae7-c188-4c68-b5ad-7e862e475185: [1,False,1H - UK MAIN]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 6217b46c-167e-4275-a860-d728a025d1a7: [1,False,1H - UK MAIN]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 63ad1442-500f-4a89-8efb-46521be65ffa: [1,False,1H - UK MAIN]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 6453143b-497a-4800-a443-565e56011d35: [1,False,1H - UK MAIN]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 65e5f024-fed3-404b-8cb1-3e1b44cb5141: [1,False,1H - UK MAIN]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 668b7268-e3b3-413e-a2bd-8d1e1455bf7f: [1,False,1H - UK MAIN]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 6975d291-c092-45c8-95a3-b9dfbc02f030: [1,False,1H - UK MAIN]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 69cf26e1-ef42-4d77-8c12-4e4062b1711e: [1,False,1H - UK MAIN]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 6cab6c52-485a-4dc8-8411-a00d22bac454: [1,False,1H - UK MAIN]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 6ce625ee-6777-48ae-8181-132cc30e5de1: [1,False,1H - UK MAIN]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 6dd3737c-4f47-41ca-b825-38c27a4b9e6c: [1,False,1H - UK MAIN]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 6f715555-d1e8-4242-a45f-cb48e83a8afd: [1,False,1H - UK MAIN]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 7143d923-5a55-49da-8c84-3b35bf81c9c5: [1,False,1H - UK MAIN]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 73c06962-7ff1-4afb-aded-fb700b5a6b3e: [1,False,1H - UK MAIN]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 74158be0-a6e5-4b69-9dd7-0aaaae9ad95b: [1,False,1H - UK MAIN]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 748db09e-cdff-4cd7-b0b8-2cb51176ad5e: [1,False,1H - UK MAIN]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 76e88698-e236-4091-90dc-f93403ef87bb: [1,False,1H - UK MAIN]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 77056200-c4e9-440b-b019-fdb8b06f3a69: [1,False,1H - UK MAIN]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 771badc3-b50e-4a88-8c25-cc4ffc362128: [1,False,1H - UK MAIN]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 787e367a-8235-4e70-b5e3-f55ddefa2048: [1,False,1H - UK MAIN]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 7930ac70-6ad0-443e-9511-9917431c7c59: [1,False,1H - UK MAIN]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 797ef2ca-4101-4c56-8640-573ba3e6610c: [1,False,1H - UK MAIN]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 7b1d07f0-8085-4116-a2fd-793b4732ad1a: [1,False,1H - UK MAIN]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 7ebb1675-3dd9-4b50-a877-02c054b7f2c3: [1,False,1H - UK MAIN]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 7ef1f6b0-0ebf-4bf8-b9e7-e1496712c4bc: [1,False,1H - UK MAIN]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 7f45a813-b963-4939-a4fa-679f110dde82: [1,False,1H - UK MAIN]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 833196db-165c-4c70-b532-4e6d1da969fb: [1,False,1H - UK MAIN]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 8510aefa-5a12-42f4-b559-b96db6d7c0d4: [1,False,1H - UK MAIN]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 85710582-02a5-4e47-b2bd-4f2d9e198934: [1,False,1H - UK MAIN]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 86411305-d759-418e-9adc-bebca5dc7e37: [1,False,1H - UK MAIN]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 866e3904-3a78-416a-a5f5-d1dca2578f3a: [1,False,1H - UK MAIN]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 86d20b59-416b-4c0d-a190-8c4787b8c57f: [1,False,1H - UK MAIN]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 87b7474b-a69b-411e-a07d-d6deb28b22d1: [1,False,1H - UK MAIN]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 88f25ddf-4549-43a1-8ebe-eb2cca7e7c1c: [1,False,1H - UK MAIN]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 89d2027e-ba9e-48cf-b735-cc987f01c50d: [1,False,1H - UK MAIN]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 8b9397d1-c4ed-4870-abd9-0a328d3dc68f: [1,False,1H - UK MAIN]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 8e3424f1-02d3-48ad-a2d4-646e03df8f6f: [1,False,1H - UK MAIN]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 90803f07-dc72-43e7-9c1a-8b6676acfa0d: [1,False,1H - UK MAIN]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 935ae291-236c-4422-8467-167ee8e47d20: [1,False,1H - UK MAIN]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 988c6b5d-20dd-438f-9e2a-a88b35172c52: [1,False,1H - UK MAIN]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 9ad379f6-eb9c-4301-964a-30ada666c7ce: [1,False,1H - UK MAIN]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 9c53241b-48a2-46fe-a6ce-725fcbf4f290: [1,False,1H - UK MAIN]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: a18d7265-f2ff-4b51-980d-a3376eca87a0: [1,False,1H - UK MAIN]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: a2d8409d-3cdb-4172-bc0f-83812231162f: [1,False,1H - UK MAIN]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: a30bc047-7753-44f6-a483-6293dffa2c98: [1,False,1H - UK MAIN]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: a4f5e22e-9c62-4770-a2be-a273bf47836a: [1,False,1H - UK MAIN]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: a66d7ec3-1265-419a-9453-e9de8d06df4a: [1,False,1H - UK MAIN]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: ab1edcfa-bf5a-4437-861b-afd2ea83a5a3: [1,False,1H - UK MAIN]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: ac1d313d-e152-4eca-a8e9-ce71591cc509: [1,False,1H - UK MAIN]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: aed6d31d-59fc-4e6b-84e6-c9ea99864461: [1,False,1H - UK MAIN]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: af34560c-0a07-472c-8a60-3ab00c9bd0ff: [1,False,1H - UK MAIN]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: b02e16d9-9d98-4b4a-b5f6-38b4d8b25251: [1,False,1H - UK MAIN]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: b09df7b2-6ead-4a6a-b6cf-1131345fbd71: [1,False,1H - UK MAIN]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: b0eed975-9d33-4eb6-a29f-ee809d23d0f4: [1,False,1H - UK MAIN]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: b59c9252-83da-4f35-a934-c5fc29368b52: [1,False,1H - UK MAIN]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: be3ee8fe-476e-438b-a001-23465fd7421c: [1,False,1H - UK MAIN]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: c286401b-8b74-4551-94e2-263d1bc23233: [1,False,1H - UK MAIN]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: c4e7d6fa-7cac-4b53-9998-6f683cb4c652: [1,False,1H - UK MAIN]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: c5599b83-4d5b-4f1e-bcd1-516d954cc9ef: [1,False,1H - UK MAIN]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: ca897579-ad1d-47ee-8b47-e7ba16075473: [1,False,1H - UK MAIN]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: cae256a0-c70e-411d-87f2-57d99fc634fa: [1,False,1H - UK MAIN]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: d170ab2b-361f-4189-8bc0-7f9c4617613a: [1,False,1H - UK MAIN]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: d1b257db-9897-48a6-a65c-ef21f1cfc35d: [1,False,1H - UK MAIN]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: d22b3e63-11f0-45bb-8099-e68227fce800: [1,False,1H - UK MAIN]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: d34ced92-7b25-4e11-b637-d05073900b0c: [1,False,1H - UK MAIN]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: d55be62c-132a-4b85-83ca-12bce8f485f9: [1,False,1H - UK MAIN]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: d6ba4ee3-2ffd-478a-8241-ef4afb7a33f6: [1,False,1H - UK MAIN]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: d9b44ba7-dfd8-4a3f-bf2a-222cc8aba6f8: [1,False,1H - UK MAIN]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: e1adddb4-fa30-494d-abe5-45866333932d: [1,False,1H - UK MAIN]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: e3cd8e47-afa1-41dd-ba4e-7f12f975a924: [1,False,1H - UK MAIN]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: e4319132-a8d3-42c0-8e04-5059da11cc3f: [1,False,1H - UK MAIN]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: e7c2f830-7197-4e57-a5df-30f751549aa6: [1,False,1H - UK MAIN]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: e96f656b-b118-45a0-ac63-f45522a505e0: [1,False,1H - UK MAIN]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: e99da648-7a8f-4b09-a2ad-916a08b1a285: [1,False,1H - UK MAIN]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: ed5851c1-8646-40d4-88f4-7ada52d1812a: [1,False,1H - UK MAIN]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: ee60d1d0-febf-4b1c-9d61-6289ffd79b3a: [1,False,1H - UK MAIN]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: efcdf7cf-9ada-4578-acea-0ba33f849b88: [1,False,1H - UK MAIN]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: f0850dfe-0ba5-401c-86b2-3f9957762d1a: [1,False,1H - UK MAIN]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: f18f5790-8062-4a9c-8154-f2c0b82ef153: [1,False,1H - UK MAIN]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: f4200f12-9b91-4d9d-b89d-7964a1ba1905: [1,False,1H - UK MAIN]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: f4aff615-e551-4576-a48a-31a9b78661b9: [1,False,1H - UK MAIN]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: f8911848-5504-4fab-b30e-f4f64b6eacbc: [1,False,1H - UK MAIN]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: f98ae12e-0708-4679-b6f4-0264c083eb8a: [1,False,1H - UK MAIN]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: fe594e94-3f9b-4548-a068-c7265499974c: [1,False,1H - UK MAIN]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: fe6facd6-b298-4500-92a3-c5e80462ff57: [1,False,1H - UK MAIN]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 038af9ac-97e2-4a50-a5c3-78097c8923dc: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 0440433a-8954-4278-897d-1ce2b51434f5: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 05965faa-246a-4be5-ab50-93bb42b36ed1: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 06206fe8-1f51-4635-908c-80c0b4013981: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 07347ddc-4b99-4de9-86d4-0b678554019f: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 089571c0-a3e5-45af-abc8-bd56c494412f: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 0897018b-92a0-4a1f-85f7-cbc06d5a8120: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 09155a00-fddc-4a94-84f7-e838c42c4590: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 0983a9b9-5017-4d46-b82f-a1d9237b44de: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 0b0d8580-b1bd-473f-a9be-0f34266c3635: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 0b22b528-176b-4c3f-877b-d0b5e7624cca: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 0b7e4fba-97b6-46e7-ba27-4af0b4b2d184: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 0b845065-2ccf-4e8d-aaad-4a8aad894921: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 0b9817c8-002a-41fb-b033-b1e068480d58: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 0c5c1d35-675f-4e73-be63-81753a43d3d5: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 0cfb354b-e306-4e42-a9eb-e4458d852fa1: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 0d57822e-792b-4954-b489-55952551c3bb: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 0d6359bb-3abb-45c4-a42f-124608d86e4a: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 0e6ffef3-6e14-4f89-becd-be196a0a8816: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 0ef76f19-ad98-49e9-bbd8-1dd701673925: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 10097bde-b26b-483a-b744-f9f3b65ad905: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 10431433-1398-4665-bf71-42850d67ce13: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 1160be32-ada1-47df-96dd-ceae759ddbf6: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 11c0bb3e-e5b0-4123-b5a4-f60df1d5bf8c: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 130fa4dc-b304-46b6-b070-8d03e830d6fa: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 15547ae5-936b-4ecb-b1bf-1ca732b1b6ae: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 16a074af-5e52-4113-9849-dc25a69d8b31: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 19567ec2-f4b1-4093-ad09-0e5ecbeb0997: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 19a91c92-1a15-4653-bca5-3f12fbd91bf6: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 1a2ad719-1e8b-4b8d-a45c-0cc4456328d7: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 1a377626-a60d-4ce4-89c0-f69278e2bb19: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 1c6e3ba1-cf5f-426e-b025-5d15cdfaf3e9: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 1ee0058d-01f7-49f3-a47d-00f977da1ab8: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 1f2abfe5-8684-4b49-8ba3-52b58a5aa7d0: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 1fac8442-a9ba-45f8-b004-3bbdcc6bc9c2: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 20b6ca73-8a94-43ee-b119-839377e236e6: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 23bddb09-1b0d-4538-9586-e57421b479cc: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 248dcef2-565f-4078-bf35-ea2daea6b6f0: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 24b3bad7-1f83-4086-84e7-712f793dc31f: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 2589ab30-1e0f-4b54-b2f3-31e38e33b7e1: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 26103d5a-20fb-4361-9081-76254d5edf69: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 279f9f0d-1953-4a09-8593-0913fd09d6b8: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 285b1797-66fe-4c57-8a75-850c6ec0c32d: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 288ed63e-120e-4032-9c23-14a354945662: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 28bf182a-2ed9-444e-bcf9-f0d2f160efad: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 2ac10045-72a2-485b-82dd-18d07351dfae: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 2ac85c60-934b-4612-a18c-4ed950a4a001: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 2c0044f8-215b-4c4a-a499-83ba39d56afb: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 2c655076-f533-4bd8-bb85-a9c1e36a5540: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 2cd7adda-3b70-4985-b01e-281d325a686d: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 2cdd5946-5006-4d0b-a55b-3accfc0bedca: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 2da9d85f-57bc-4ce0-969c-44d488e6ae8e: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 2e16f31e-35c6-45ea-b4d2-9618106682c4: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 2eb05573-1c48-448b-b3d9-7043a43d5903: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 2fe363a2-a8f6-42dc-87d3-9031b68883df: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 3087667c-3319-40af-9eb3-9df26c048d3d: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 31e8cfa9-6f6f-4c10-a80c-eb1c57f1ad3d: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 32c9dfef-895c-4d57-a545-4c443f615b89: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 33147bd7-bdc1-444d-b388-498db804566e: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 33b1860d-53fc-4493-8c8f-922ccfeb1f98: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 3458dd48-e2da-48e0-8073-f547d75e3dc0: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 34f4b409-0364-4227-b97c-2d653a93df00: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 357a7559-2c9d-416b-abfb-d253285d84ed: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 36859cbb-6fe8-4ff6-ad30-6c4e9871fc59: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 375932ef-1bbf-4f8b-8f64-0b5d6c1f95fe: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 379b5d3c-079a-4c65-b742-f38cf6dc7a11: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 386351b0-9328-4a23-923f-7636d0c256a1: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 39a239c2-eddc-4a8b-834e-74478b0d0219: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 3c4ce7ba-2479-4eb8-8778-dba3d4a9e18e: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 3e21182d-aa19-4be1-b697-8b2d05c55faf: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 3e816263-c34e-44d6-b0f2-565bf531204e: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 3f4737b4-c4ac-4f05-832d-8272912bf9c6: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 3fd9ab01-33b1-424c-a5d6-2be3263db299: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 3fe70008-9840-412a-b177-eb2f6a7341ee: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 406b764c-cbee-4d8e-b9e1-23dc15a65a6c: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 411bf069-7529-4331-9aeb-537c8aaff705: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 422c7acc-1a76-4fde-8dd3-3b2057dd9005: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 4238c121-4fec-4c6c-bb7a-260863d1c698: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 427081c5-1ea4-45c7-82b3-6ab6cfcb2f99: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 42fb5da9-7d2f-462a-8e30-700862453e1a: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 44a0f673-a597-4e27-a77e-da2799a49f06: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 45887517-e538-4325-8581-764b420282bb: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 45db6bbc-95ae-4f51-8c69-56e769d209c0: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 477c09c1-37be-4625-98b1-c6cfadbeb736: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 479b6f51-fca4-4911-8654-1396b199dd3f: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 47f49da4-6703-4df2-ab19-c60d2ae567ab: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 4aa3c752-93a5-4c94-bc6a-4953c2850f23: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 4ac1d022-1674-4f3f-a07a-11997fdab895: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 4c237c2b-df3c-46f2-b6e1-256813450823: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 4c4c1d6b-6b10-4992-a2ee-8741fbd6d2d0: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 4e902f59-1d7e-45ea-944d-ff41d9f96f05: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 504b28cd-280c-4729-867b-b78c046f775c: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 5055802a-ea5a-41b0-91bb-3347776c6f9f: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 5185dee7-44d7-4d5b-807e-d0fe76d2fae0: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 52def4a8-8160-41a5-bd43-660db90d9982: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 53e3f3a9-e577-433d-bcc3-61d5f82de8eb: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 5552ba66-d7b9-4275-bbc3-963c5976028f: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 5a2a9a01-c45a-480c-82ef-54a4ecf0b69d: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 5a2ddd5b-cec5-4008-8dcb-78546be3a7ee: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 5b621bf7-f2b7-4675-b66e-a917524ae82b: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 5d6c4b68-4612-46c0-bc04-ed61e1c59281: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 5dc17ba0-281e-4961-8c6d-7ced09c9878d: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 5e65f6f9-fdfd-4bf5-b8b2-1bf637221200: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 5e9081f5-87d0-43f8-af04-5f085206a441: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 5eb50715-f959-4139-8226-b242a9466b5e: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 5feacc0b-8eaf-46d1-8f19-ee80198cd309: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 601224cf-8c68-4480-b6ce-a9a9e35a89e6: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 605233c2-17cc-401f-af20-82bd9a5f3ac2: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 62653282-14e9-4dd8-8698-6dc9958fa9a1: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 62938a4f-8ccd-40e0-b7f2-68f573512375: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 62ae2ecb-437b-4532-9144-5aa5f81d3ee9: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 6344c2d4-2974-4d38-a62a-4971b41791f8: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 64183671-fe7f-4548-bb50-e98161d582a7: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 65573094-8a6f-45a9-9b4e-61a9c0ac62fc: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 6588acd7-5a91-4d2a-a3c7-f71f8bfe79d7: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 6707769f-ee4f-4a7e-b574-2080dad95a89: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 672ffd69-ab67-42bd-8fd7-2d636f3f3b0b: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 68d948c8-b68d-4569-aef8-fffc2cf6fa61: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 693810fc-5d49-41bf-b4fd-24255f74aa00: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 69e29a2c-1a77-412f-b75d-cc37a4d512f3: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 6a9cac7b-5ce3-4fac-bc34-ee6a5166fb3b: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 6afa8cf2-cae0-4112-9675-022e33d73f2f: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 6b696a43-799a-4782-a920-c190685ba53c: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 6b97eb9e-2042-4cef-8845-86629c3236b9: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 6c63005e-ba4a-4fee-b81a-b90b91ea18ca: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 6da1c70e-b24d-429a-842f-487f2e4bc1b2: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 6e05b2df-8c1e-4efd-94f0-45e73e02fe59: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 6eaaa882-8339-4698-933d-79bd0c7ea5cf: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 6f925d38-a18f-4675-aae4-a2fd992c245c: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 6fe7d03b-ccd4-4972-a868-ce95f36452aa: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 70ac4b66-6989-4796-9822-e91f90cde06b: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 70e70caf-4c5b-45cc-9721-e53fd642f4ca: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 71f7ec6d-4d94-4cd5-a9f5-ce16c761df53: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 724fcba7-d646-48d5-8420-de05982ee64f: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 7291b8b8-1f6b-4082-a7b8-59b20f0e3722: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 72a46b1b-9ff7-489e-b41b-1a6e5e7827a9: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 734a2ec1-dba3-4ac1-bfba-a6940a916c02: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 73b5cb93-2544-4256-b64d-be5c65e158f2: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 74cb1f56-8c28-4fa3-ac7a-e50e075ad154: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 751f36fc-5121-4a2a-be07-e40bacd111d4: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 7636ab03-aaae-46cd-b555-3114f17c5ce8: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 76dabbe8-99de-4ac2-991a-87fd0163be7f: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 776960bc-0ef4-4dbf-bd38-67892c9816d2: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 78376182-7434-47ef-b488-848a84ea190b: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 7c0027b2-ec63-4360-9e47-1e1f28019a72: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 7cfdb6d2-292f-4da7-bf0d-5b209c88fcae: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 7f325d06-0df6-4ce5-ba14-dafc6c9a453d: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 80387496-8230-4fdd-82bb-5eb6b5e180cd: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 809ad70b-97f7-4ceb-aad7-ae2548732f4b: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 80c77cac-971c-4647-bfbd-bd0defbb3982: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 81389f19-adbd-41b4-a031-671fdf20fd2e: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 8196dba8-982d-44e1-902a-9517b010700d: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 81e4e328-250a-4000-b860-d13100a16129: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 82e7db7f-5738-4008-9baf-0c09eb746e4c: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 83aff62e-cb08-480b-8c41-f9e6682b7bf1: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 84ee9fdf-2215-4857-aeb7-149ac43a86c1: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 850f8fc7-0fa8-4718-8881-9ad477e3a666: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 8523d51a-634d-4617-9cb9-08f04acdb6df: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 87eaf16f-93b0-4bb9-9da6-4ed6df1869c2: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 887878bf-765c-4884-97aa-60020ccc5568: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 88a870a2-3e4b-4cb4-9285-327bd9a74cde: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 88c85048-fc1c-4bd5-81e1-5df23618b2ba: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 897a47e5-7c5f-40ab-a08b-aaaa5c6a75e3: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 8adbde62-eefa-4248-8c2d-442fa6acd2d4: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 8ae4b536-dc87-43b4-8e63-9ca0bfb4ddf7: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 8b6c3236-5a0c-402a-933d-4299ec7561cb: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 8c106f3a-02e6-4fb9-aecb-302a4b0c2363: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 8c3dd782-559d-4ea0-9e1e-dedaceca6ea7: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 8c5c8d6c-6688-4cfe-9097-462806f51e96: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 8c7d818b-3327-4975-8cb2-f15016bae29b: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 8e1b43ff-e69f-4015-9c96-8940fee08ed3: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 90bd2c2a-2293-4696-aa3b-65b548cfa04d: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 91e8c9e8-0e8f-4c44-a4bb-aa99e505c1be: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 92d73e97-3b67-47d1-9275-b5d89c2d87e0: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 94a041cd-26f4-4a0e-975b-584e7d3aa925: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 94d42537-993d-48f5-b479-859217c18ce2: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 955a5cf5-ca65-472a-8716-043a2202afb9: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 96169a2a-daa8-4071-9d51-1c7c4cdc1029: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 963e7522-6eb4-422b-b264-c17aee9835e7: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 970f47ce-4492-48ba-b85b-3ca2793cd1c3: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 9837e30d-4ee2-4b4e-ba39-e72fac9a9e77: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 98f6b114-0f70-42bd-aa65-002dcc0a337c: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 9928d73b-e5e0-4e01-b159-56a0835a57ac: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 99742c5a-5529-418e-b1e9-8058fb16af39: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 99b4ca8a-d448-48b9-b02a-f1b4f8e2b440: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 99cfd61c-d297-4b73-bd39-05be1e5c03e9: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 9acfc16a-cd37-44ad-bd5e-8b64a9469e59: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 9b026bad-663b-4d9e-b849-1ea7a7f9ea69: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 9b4108df-6cf5-49a7-adad-8a1d083b1fe1: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 9b53845e-1d78-4d01-96d5-f089c51b937c: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 9c52ff14-0eef-4284-b934-820a7d8ff132: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 9c77c902-ca1e-4943-80b3-c52806a0a4eb: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 9d30356c-f16e-412e-aa86-20cf968786f2: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 9e2caee6-7b5e-4d3d-9243-cd33f7e12d68: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 9e31897b-70d2-455c-92ca-2114b40a2252: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 9fc71dd4-e84b-442e-b029-72c309a75206: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: a05b494a-7175-430a-a725-ba5a9fa05b61: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: a18bbcee-368c-4a6f-8d96-5cb251df9680: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: a27448d0-6054-4aaa-87a4-215394692925: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: a2e91a8d-acc3-486c-84f1-4c5b21dacf8a: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: a413269a-409d-441b-8d37-f8fe57be235f: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: a453c52c-4874-44d9-b8ea-5f9017988a2b: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: a65da3f9-7547-466d-a636-6cd7d4b20bd5: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: a6d4710f-3f32-4aa5-a762-7700a00df32c: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: a86102f6-6378-4875-ba49-0589f429d24c: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: a937384b-864d-4ca8-bd72-e13c0912096b: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: aa44540f-418b-4510-b3cd-d9cd2b911fa1: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: ac22bcee-69cb-47f5-9dd6-bc75f03e28ce: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: ac790592-b9e0-47ed-a4e0-68e5b7bcf4fc: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: acfdc0a4-e04d-48c8-8220-33b84ef8c43d: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: ad264240-d2b7-4bc9-bd0f-7799c3733cc3: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: adc57459-498c-4131-9bbb-79cf15b11a53: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: aee5c3bf-caee-43c4-a77f-a2f233ce2efb: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: afea3e2f-366e-40d4-9255-6a30c00c36c1: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: b0709376-38b5-46af-8502-1ddbbdaf7178: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: b0f7e369-d9b8-4ec4-aa76-c517b80c21cd: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: b504b17a-2c60-4161-9e31-96b4db5e3fd9: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: b57fea12-6a39-44e5-94f0-7149b3977465: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: b5c1d047-3670-4dfc-9a32-a2b4867b749a: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: b6706f3e-e6f2-482b-9a0f-82168a249f7d: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: b7fa2650-8f61-4038-8459-5d90a2475959: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: b8460163-bfcd-4945-b0e2-024884b987a5: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: b847b36e-b51b-4c4d-877c-fb3725beec67: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: b99c8f3d-7321-4abc-ac73-a3bfcc76fb57: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: bb0a8926-96d0-4268-8c69-5bfdba0548c1: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: bc0af218-d478-4094-815a-0e583cb42beb: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: bc8021f8-9f70-4057-ae61-4bd01608212d: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: bd61f916-1b16-4b5b-967d-3da5923d8c47: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: c0b7b06e-d9d5-4284-bf4a-5854a1f14d05: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: c0e6ab93-0951-4309-b9fe-97a106155b92: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: c2047e37-f758-4179-b4b8-8ae5f6983c33: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: c29e4fa5-f06f-4feb-876c-89274f516704: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: c2bba3b9-fda7-4549-80cf-ed641adc8411: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: c2dd0396-9be7-4d4d-9788-22f3023c4601: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: c402c385-4d06-495b-8ff8-28e80d17aed1: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: c471b994-9781-4ae0-8559-e852d565dea9: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: c70e4cee-d21d-4575-a692-da905763eb93: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: c8e8671a-690e-43cc-9f8e-2cb5a7779f56: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: c9643f8a-90ff-4219-bdf2-1ef9003c50f3: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: caa28c20-a81d-4e82-aae5-765ee48414c6: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: cbc361a4-9ecd-4e4a-8039-67126c0ea45e: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: cc927cf1-f459-454b-997f-33f42815ad82: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: cd1ce10f-85ad-4199-b2d6-802f6a9c7e04: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: cf016535-1152-4c9b-b819-3640280488b4: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: d0777ea5-b6c5-450b-a392-afdf97a8914c: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: d13a75f5-ae0d-40fd-8c9c-a1ac56d23341: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: d1e386fa-2425-49aa-af6e-11334b29fce6: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: d21ee913-6a61-4bd2-8f14-a78a233cea83: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: d2698670-3c80-43ee-bc8d-e74a39383dcd: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: d2893b0c-197e-4113-ad9c-308a30e48970: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: d30d42d2-855c-49ef-803b-10074dac27f0: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: d33a3ede-9a72-43cc-8ac3-868d83f06f86: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: d395bf3f-bd92-4626-af11-959dc6f97a23: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: d59e3754-1938-438b-8577-cbad4ff8fa11: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: d5a3aa5c-5a36-453f-85d4-f0fdc916ae67: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: d606cf67-130b-48d6-ab86-e1e4fee428db: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: d6710a39-a2cb-47cf-8bf0-6c2ea8d3b173: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: d803295d-7130-4887-b981-abc0b89096c8: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: d880af2d-b6c4-45e2-b9ca-6f029f157f45: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: d903459b-2f77-45c0-9837-328328ea52e4: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: dad608f8-7694-47a5-aae6-154fbfa3232e: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: db17c553-f9d3-4a59-b380-9a9b51541254: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: dcc62bc7-b34b-4607-bb89-88211b81d572: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: dd03e36a-58a7-4b38-9fd7-6e0de85def13: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: deb9c74f-f502-44f2-b6c9-b2b1bc6b6743: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: e01fa5bc-9a01-4840-bf45-c154a5ae340c: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: e1693149-6cc0-4720-9b69-965c1e77f5d4: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: e1ebd58b-1bf1-4dcf-b9a3-8f6660e65f37: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: e36b669c-ee56-4ad1-81a5-72107422aa28: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: e3c0b1be-fff4-4ffb-a920-f0b8ede51c00: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: e3cd20ce-a525-4074-b5d7-c22f997d3bca: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: e4157259-4621-4103-b965-6ba701903d35: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: e5167004-1432-4a3a-99c5-53cecf2d810c: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: e55ee467-6806-4c2e-a34f-b42bad1c0cd9: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: e62806e7-a1cd-480f-95f9-9c3c8946cd3f: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: e80d6164-4835-4795-82fb-7c1e4966ca38: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: e84f98fb-20d3-4c5b-bea0-d70f35ca99a0: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: ea033ab1-2de7-491c-a62f-b873308e940a: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: ea5bf5d0-d9b2-4bf6-8899-41a685dcf047: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: edebf866-1315-4df8-b4bc-4587e5fb3142: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: ee9f08a3-b538-47eb-a1d3-4166711fb84f: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: f04802ef-b696-4587-a028-00ed6ff275f0: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: f0fd62a0-b812-4acc-9df8-9f5ffbafac86: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: f1c5b7a8-030c-4b8f-a43e-f89a6aec987c: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: f2481054-5d87-43b7-82cc-437924fff5a7: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: f24d3ad2-a522-42e6-8950-6eef6e478042: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: f422d455-5992-4ae5-8687-f3fac4a887a2: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: f606d972-93ad-42ff-9d6f-0df5b15f2495: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: f6c30cfc-b7aa-4713-9816-fe3033bde9ee: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: f766857c-639d-4d19-a717-c0d5f30938b3: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: f7c7e496-4adf-4c9c-94de-3637ed123254: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: f95418fa-46ec-47d6-8db2-8d074427b54f: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: f970dfba-f29a-43cd-b843-bc8b4991db76: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: fa25d1af-cd4e-45d5-8747-24502f5d8e31: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: faca86bf-ffef-4501-9245-e57f8e55df01: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: fb26f9f9-b6a0-4a00-8959-2d65c4c9c02b: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: fbd9ee30-ea0e-4e79-8579-d943c90c3b5d: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: fc166e2c-d9b3-4640-bbf4-292b1ed051d5: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: fc976a85-ccae-4aec-afc0-4409b32d0c31: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: fdc5c72a-eb53-4aa2-bef4-afc95537acbc: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: ffac29b7-10ad-41cb-9db0-530373152f33: [1,False,24T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 209c4bd7-e167-43c5-826a-f20db2e054e3: [1,False,24T - PACKET]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 3b7d1faf-340d-4024-a23d-30dbe0e1ffba: [1,False,24T - PACKET]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 5c33a3b1-3770-4fe7-be10-6330f304102a: [1,False,24T - PACKET]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 5dce33ff-eb30-4434-9ef8-1970fae0afd0: [1,False,24T - PACKET]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: b7281123-c893-4078-869d-b97f1e81fe23: [1,False,24T - PACKET]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: fd0ede1a-eda2-4ad3-8eed-b69659457096: [1,False,24T - PACKET]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 24cf9003-1d89-4377-b0b9-43a51e019693: [1,False,48 LARGE LETTER - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 331f1418-e1ce-4405-9dc0-c6f2d4e9b44f: [1,False,48 LARGE LETTER - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 39630311-cd5d-4d6a-80e7-9e13634cb7c3: [1,False,48 LARGE LETTER - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 94ccc311-21eb-4c5d-aa75-bd05bd5307d8: [1,False,48 LARGE LETTER - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: a6054c57-e192-4a44-8777-f29334762898: [1,False,48 LARGE LETTER - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: e7ee429c-1c27-4d5f-bafa-bef65cfd9f38: [1,False,48 LARGE LETTER - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: efbfa8b7-7dc3-47f1-8391-cefa07434187: [1,False,48 LARGE LETTER - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: f8e8c788-0bf8-4f92-a8a1-06e8b7cb1535: [1,False,48 LARGE LETTER - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: be29b15a-3601-4a49-b37f-d8eea3eb9578: [1,False,48 LETTER - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 005a6012-1132-46ef-a3d3-723c9fc6aee0: [1,False,48T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 012af680-47c8-4091-93cd-367139712d8d: [1,False,48T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 01ee0859-7a28-461b-9f8c-9b66a3a2769c: [1,False,48T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 0262dcb2-ea62-4a82-8922-04c031ee77cf: [1,False,48T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 0335786b-72ef-4ffa-9a0b-d6931dc86cef: [1,False,48T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 0475f8dc-40f2-425c-9b87-dce345af3129: [1,False,48T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 0496c6c4-c613-4360-8f2d-cf8d3a5503b5: [1,False,48T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 058a9391-4be2-4bdb-83c4-59daf4557951: [1,False,48T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 0606099f-828c-48c7-9940-90cba11cb26f: [1,False,48T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 06f4417e-4067-4a92-bad9-0d8dabc6b1a6: [1,False,48T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 077b3dd7-1198-47d2-a33f-f832fa0e778f: [1,False,48T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 08c78fe2-e1bd-4ab9-a3c7-75b06cc70817: [1,False,48T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 093ae80b-ab77-4f50-beba-8cf772a03315: [1,False,48T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 09686b45-f237-4f45-9657-1100fa805cfb: [1,False,48T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 0a2859af-3692-44f6-9616-de9144e4d4b4: [1,False,48T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 0a3293b3-9e73-484e-85c3-4b2d8d25ad5e: [1,False,48T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 0b20dfbc-7354-4813-b464-07579a6d94d8: [1,False,48T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 0c3533bb-35d1-468b-bd9a-6cf8cbf94236: [1,False,48T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 0d25273a-fc34-4ac4-860c-97776df5263e: [1,False,48T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 0de0c8c0-1757-41c4-a09e-640ce29c722c: [1,False,48T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 0e1e2c24-801b-450d-8276-d83cc3265eb1: [1,False,48T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 0ef23546-651a-4d39-a4d2-2e62e1a1c539: [1,False,48T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 0f0276f1-bdca-4bc3-82b4-9ed3a1fc43cd: [1,False,48T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 11ed74da-f9d6-4985-9771-38b544ab28d5: [1,False,48T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 12179225-0d0f-49a5-b3d2-342e16806880: [1,False,48T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 130eeb74-61b0-44c0-bd9a-c7c821d96dce: [1,False,48T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 13975e17-140e-4932-ba6b-25ea35a3a6f9: [1,False,48T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 1424d268-211f-48e3-922e-a2c220c66ff7: [1,False,48T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 152d036a-00eb-45b5-99b2-0fe6935d3780: [1,False,48T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 16157773-8260-4c73-8133-0a5700685f5c: [1,False,48T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 16200c0b-ea7d-4e0e-a5ef-c29361c847b8: [1,False,48T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 17d7c85d-8c5e-447c-9a1a-a13d19ea2beb: [1,False,48T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 186c7d2b-7a42-45ad-b7bb-052cafa987a1: [1,False,48T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 18843257-8959-464a-875d-1e7a37c3a2af: [1,False,48T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 1a7b386c-47d1-4c77-9f2d-1c952f52423d: [1,False,48T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 1b70f444-2eda-40fa-8b5b-d863f7104adc: [1,False,48T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 1c2dbad8-f702-499b-93b9-58a392966f35: [1,False,48T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 1cf9ca6d-5eb7-4307-b609-1e3e30427d44: [1,False,48T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 1f8bc1f3-666b-4a3c-8099-c390598071ae: [1,False,48T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 210f4cb5-a32c-49d7-8cd0-b2c02b6cf846: [1,False,48T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 23829ce4-d980-477f-9dea-ffc9ac82495c: [1,False,48T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 23fe8b23-9049-4f09-96c9-b1c13dee0916: [1,False,48T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 248eeb1f-f039-4d7e-9d59-2b5039c02528: [1,False,48T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 24d5f113-7fa5-44ec-b732-7b2600c9af80: [1,False,48T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 263b0e71-4948-4fd9-abdc-9264bae944f8: [1,False,48T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 2732735b-7841-48e9-80fa-8b83e9e3e7f6: [1,False,48T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 27726613-106b-4554-9ffc-324aa2f08cfe: [1,False,48T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 2b9092e6-c2e0-4a4c-a5da-b469738aa2a8: [1,False,48T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 2ba186b5-38b6-4e36-b386-f0e90233ae27: [1,False,48T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 2c5e79ef-b291-4875-b3ff-d4ec816be201: [1,False,48T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 2c747af2-c0a1-46aa-bc6b-f4eee929968e: [1,False,48T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 2e65a7af-2d02-4872-a4b5-04da5db68513: [1,False,48T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 2e66bf44-7556-4885-aba7-10e13abff283: [1,False,48T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 2ed5220d-a7c2-4387-af80-6ce0042b9bfd: [1,False,48T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 2ef397d7-5a85-4805-a684-1d5a8f96364c: [1,False,48T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 3010aeaa-6152-4aec-a043-b9647a1b2717: [1,False,48T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 303b1809-bb75-4727-9d66-b31469f2fd4a: [1,False,48T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 31072e22-2256-42e4-822e-d791a06628fc: [1,False,48T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 31b3550b-84b6-44a8-85ba-936695e7cbce: [1,False,48T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 3243fb0b-7923-42ee-b64a-731b91eb9f38: [1,False,48T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 32a842d1-a176-43a3-8886-6deea5c9f2ce: [1,False,48T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 32c3a3a9-2675-4cf4-b8eb-d1eba354b0c6: [1,False,48T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 3330d3df-2d77-47b5-b1e1-65b58aa91240: [1,False,48T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 33616102-0665-4336-bd5c-c0ed11998ca0: [1,False,48T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 33d5d395-e516-4570-9cd5-41fcec0307d4: [1,False,48T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 351379be-3bad-4c8f-9e05-df51b2fd1969: [1,False,48T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 352a67ce-0c1f-4966-bab3-7f3e63bb2000: [1,False,48T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 361d690a-93e8-4389-9500-f0da685e75b3: [1,False,48T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 36e1ddc7-bb65-4c77-a7dc-038d1fbd1cbd: [1,False,48T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 3773ed97-5458-4d85-9b5e-95640f09ac1a: [1,False,48T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 38227a88-b904-4fc3-b093-83db97de8fc0: [1,False,48T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 39681156-1aa0-4fc4-83ec-adb3e5b1f77f: [1,False,48T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 3a0b9b74-63a3-4bdc-aab2-434a584189ca: [1,False,48T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 3a5937dc-9d2c-4868-83b1-3ce72418cc6c: [1,False,48T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 3af253cf-72b8-427b-91dd-d991dafa55a4: [1,False,48T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 3d5f161b-4502-44b9-9936-f986406f6350: [1,False,48T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 3e9ca7c2-45e2-4c34-9d12-c07f7f12a685: [1,False,48T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 3ed26646-704f-41a2-baaa-9a6dd37792f0: [1,False,48T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 4132464b-c861-4b79-9b9c-e959d433ae34: [1,False,48T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 41b28caf-b476-4acb-b794-be14af20bdcf: [1,False,48T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 4422f94a-1aa4-451a-ad39-600236a1bc8a: [1,False,48T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 4456130e-a98f-427b-a302-993f41d4caa4: [1,False,48T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 45374956-c40e-48bd-a3f1-e374763164dc: [1,False,48T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 4577df55-5378-4ca9-b1c6-c5acaf0c054a: [1,False,48T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 45ec18c5-042a-4e63-a14a-f5e03cb202c5: [1,False,48T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 4617ceb3-bce2-448c-bcee-80abd078c8d7: [1,False,48T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 4642eb4a-0c07-44b4-bb58-ab69c76ce3ef: [1,False,48T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 46838212-5914-431e-b822-806c4436973e: [1,False,48T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 47593919-da79-43a8-81f6-4ea38db29e18: [1,False,48T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 4a2bb0a0-9a0c-4788-8b04-7a521e541685: [1,False,48T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 4a32775a-1d28-4735-9e33-8be721168d41: [1,False,48T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 4a3fdd43-3132-49b8-8911-a33b87d2a769: [1,False,48T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 4a588afa-7121-439f-af1a-e1c9a219472f: [1,False,48T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 4aa506a7-0e7a-4fdf-9b86-e1cc311ad519: [1,False,48T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 4ae14278-dca8-4441-818a-dbba749155c8: [1,False,48T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 4b44c781-5aa4-40ef-8502-c949b0b87bfe: [1,False,48T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 4b4ffa43-e1df-40e6-b47e-e97bd10e1a8d: [1,False,48T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 4d1aa49b-218d-4090-87eb-811197fccfe9: [1,False,48T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 4d2cfcc4-c9b7-47a6-bbec-33a2d1e27966: [1,False,48T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 4e5acdfd-9e8a-46f5-9ae3-826fdd2c8f14: [1,False,48T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 4e92cfae-7b8a-4c03-8b3c-7f6164a5dd19: [1,False,48T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 4ebf59f9-a9b2-4973-968e-c463f87211ca: [1,False,48T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 4fa8602d-77f4-459c-a422-9e4c61c82589: [1,False,48T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 508f50c2-83a2-4659-92da-8af7fb32dd9e: [1,False,48T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 518285c7-4a86-40f2-bbb5-2b92718b4bf0: [1,False,48T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 52e62af8-0be0-4367-8d45-99e3b090c35e: [1,False,48T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 53aa520c-1cc8-4748-bfa6-f4570d573a4f: [1,False,48T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 53d3e36b-6b77-4239-b622-a7fdb1362a43: [1,False,48T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 549248a4-7c29-45e1-870b-3052841cb124: [1,False,48T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 562676b3-b54e-4a6a-8ba9-595c5245422b: [1,False,48T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 572d153e-d59f-4306-8bbe-57ee1edcc046: [1,False,48T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 58392bf1-9a84-4739-9d59-c653d23d860a: [1,False,48T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 5a17b0e5-469a-4428-8bb0-55f92d7a4277: [1,False,48T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 5a951b82-d172-4eca-a1c5-102e3a5f507a: [1,False,48T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 5c1bf8cc-7b9f-484d-a462-3921a3e65e3a: [1,False,48T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 5f7be2d1-ff78-47aa-ab6f-2e5ccb5ab244: [1,False,48T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 60be3af9-70e7-47ec-9e9f-ad098d72b163: [1,False,48T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 6110b300-8b13-4417-a36c-29fcdf17a69b: [1,False,48T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 61204a02-b90b-4a0c-9c81-0b591cc068f8: [1,False,48T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 629e0425-6e50-4a38-85b7-726ec51cb06b: [1,False,48T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 6315c08b-54d5-480c-9ef2-296a1b1b2086: [1,False,48T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 64f8906e-6fd0-431a-8220-f999f29327de: [1,False,48T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 65510e55-f9e7-481d-9782-45e8c49cde03: [1,False,48T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 666e51ef-f739-45cd-b28d-d8778a4ff6f3: [1,False,48T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 6724055e-8a3f-4656-b2ff-91ca38b9a3d9: [1,False,48T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 68749d52-76df-411a-a8df-bf70244183f7: [1,False,48T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 6a04a585-b263-47ff-8a1b-449286f3030d: [1,False,48T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 6a26fc62-8919-49ab-8ba8-c5311ceea262: [1,False,48T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 6bd9d4e8-e605-4217-a2ed-1b6b4580f9fb: [1,False,48T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 6d04a4fe-4393-4fc4-a62b-fb4635f5c418: [1,False,48T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 6d530ec5-9690-417e-b7ef-1c267863f28c: [1,False,48T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 6e887f7d-08d0-48e2-af67-5a6899f14d13: [1,False,48T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 700fe089-a6a7-40ba-bce2-7311036b9642: [1,False,48T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 7015b24f-3d4b-4375-a4bf-a5ec806e620d: [1,False,48T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 70590d48-ab46-4ce8-b172-0c5b8bad84e5: [1,False,48T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 709518b6-345c-4fed-a021-d84275ebdbf0: [1,False,48T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 765c4fa5-688f-47b2-a41c-cdfef27877df: [1,False,48T - AMZ - BA]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 8eb9bb08-4afd-457b-ad96-f0e93c1aebf1: [4,False,YODEL LOUNGER XXXL]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: 1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: c3850c89-d305-4a99-9e7f-1917400795a0: [4,False,XXL UK MAIN]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 22879b7b-f3f9-45c9-88ad-41c0bfca93df: [4,False,XXL UK MAIN]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: b2a18851-9f95-4266-a669-fd3220738c35: [4,False,UK Mail Next Day - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: f5edc9f3-0747-46b3-a623-92e9c58dd968: [4,False,RM MONTREAL - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 68abf144-2606-48e0-b84a-32018f937163: [4,False,RM ITALY - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 7a2eb7db-1dac-4e78-9e65-6b854913dbec: [4,False,RM GERMANY - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: d1aa9fda-f0fa-44f8-a976-e58d75b65010: [4,False,RM FRANCE - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 83a5d510-b129-4a44-813f-fc42c1f05691: [4,False,RM FRANCE - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 3dbc8a0a-1fd2-4345-b503-7207343c3932: [4,False,DPD Next Day 12:00 - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: fae33594-a087-4663-a81c-965324f60c82: [4,False,DPD Classic Expresspak - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 56b949a4-50cc-43dc-8628-ea5e223cecfe: [4,False,DPD Classic - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: fce2463b-96dc-4201-86ac-643fa0928d88: [4,False,48T - PACKET - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: f1774705-d517-4e9a-a500-75dcd3688ac5: [4,False,48T - PACKET - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: cdb566da-4605-4145-8a76-c20931b27665: [4,False,UK Mail Next Day - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: e6585a19-9220-484b-9389-27f6d7418629: [4,False,48T - PACKET - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: c3a23121-879f-464f-836d-a4bf28a77a90: [4,False,48T - PACKET - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: a17bc221-846a-4615-80e1-389d7f2f1976: [4,False,48T - PACKET - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 71b6dba8-e2cb-4e34-9677-e877e2dff31c: [4,False,48T - PACKET - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 608bf888-4b13-43a1-9339-293ca14af64b: [4,False,48T - PACKET - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 5ea587ec-22bd-4eb6-a357-aa4117a30a6f: [4,False,48T - PACKET - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 38f2068c-e6f0-44de-829c-dd08d320d8d4: [4,False,48T - PACKET - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 2c1cc50f-25fa-43a9-816b-b0eb74cc2ad4: [4,False,48T - PACKET - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 1d1677f1-debd-4297-bf33-013960ec6f6a: [4,False,48T - PACKET - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 0b3594f0-c632-4bf9-9592-bd777ce7605d: [4,False,48T - PACKET - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 3bc84e93-bbe1-4ba2-99c2-cd70dd385833: [4,False,3H - UK MAIN]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: fcf1f831-dee2-47a3-b2af-ee1e9678c733: [4,False,1H - UK MAIN]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 81c0362b-3c4e-43ce-a3f6-5ac56c3032d7: [4,False,1H - UK MAIN]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 7f942cf0-4815-4702-b0ad-b74794c7c100: [4,False,1H - UK MAIN]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 5aa0e132-0345-4969-898e-6511a1175998: [4,False,1H - UK MAIN]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 22c88bf4-e0f6-4ea0-8c70-aaaa0fd7cfb9: [4,False,1H - UK MAIN]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: b79958b6-e7ce-43b5-9d7e-b7d4e42fab92: [4,False,1H - BT]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 7fa22520-c5fd-43f8-be05-c51d2f3edf21: [4,False,1H - BT]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: f563f11f-70e0-4620-bfaf-a57117c6f862: [1,False,YODEL LOUNGER XXXL]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 16ba9df3-5f17-4e32-bcff-f2128bc74a64: [1,False,YODEL LOUNGER XXXL]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: a8297186-b743-4f44-abd4-99aa351f7b03: [1,False,XXL ISLE]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: e6879e85-beb2-41c0-a6ef-8419a9f93a2e: [1,False,UK Mail Next Day - XXL]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: b9ca8064-2f1e-400a-8b07-06819d36eaa8: [1,False,UK Mail Next Day - XXL]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 426ae142-d93e-4217-82a5-16bedb0ba6b9: [1,False,UK Mail Next Day - XXL]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: f7b742f7-48be-4c1a-a041-3a09a0491642: [1,False,RM VANCOUVER - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: e0f6b653-4633-4c0a-9282-7386838f3065: [1,False,RM VANCOUVER - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: be4f788f-2720-4c2b-a7c7-e485f9749593: [1,False,RM VANCOUVER - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: ad0745c9-4442-48f3-8e0c-3725323dbb28: [1,False,RM VANCOUVER - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 85c490a8-0983-42b1-9e9c-c9ff50cc1fb9: [1,False,RM VANCOUVER - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 731fa41e-864e-42b0-8624-5554f22c1ac4: [1,False,RM VANCOUVER - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 49518b34-7fc5-452d-8e85-dfc57362ea95: [1,False,RM VANCOUVER - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 4377f241-5b84-4e63-8fa6-19f0f0153474: [1,False,RM VANCOUVER - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 149419cf-f132-46e8-92be-784bcd93da43: [1,False,RM VANCOUVER - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 0f6fd091-ee3d-4773-a993-55735aef8119: [1,False,RM VANCOUVER - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: dfe05612-1a06-4105-82dc-3bf8b750c5b5: [1,False,RM USSFOA - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 3239d4f9-0be1-4d26-a0c4-5e7dc6b2c076: [1,False,RM USSFOA - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 2b1a498f-f31b-4775-9d0c-a49c98637865: [1,False,RM USSFOA - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 0f99c3dc-df5c-4c1d-b710-9f9a9078da2c: [1,False,RM USSFOA - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: c57f2005-a12e-43de-aef4-c950bfa6c624: [1,False,RM USORDA - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: a0414290-a73d-4a26-8123-a6f4496660ab: [1,False,RM USORDA - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 92fdfff9-7343-4043-95d0-1be8d3e00774: [1,False,RM USORDA - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 6c52763e-badc-4d7e-9165-cae76d4d9d74: [1,False,RM USORDA - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 6179bb17-feef-44cc-8ec2-f9e640396847: [1,False,RM USORDA - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 4ec27f3a-1305-4897-a4cf-e8324944d25a: [1,False,RM USORDA - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 44c3277b-8c4c-47c9-b987-ed80b1c83380: [1,False,RM USORDA - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 208d0871-daf7-4169-b860-9bb516a995c0: [1,False,RM USORDA - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 1965ba6b-0156-4749-a1e3-4ed7a419d81c: [1,False,RM USORDA - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 0e4edb3b-5acb-4227-9b76-a91f297cc7f2: [1,False,RM USORDA - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 081860df-3349-4f17-bc87-14baab2ee3d2: [1,False,RM USORDA - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: fbc883e4-e960-4769-85a8-0de06ea26069: [1,False,RM USLAXA - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: f3e11631-dfc4-440d-96dc-f04fb7810127: [1,False,RM USLAXA - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 9eceff7d-816c-4908-9776-d1bea99a5cdc: [1,False,RM USLAXA - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 856a3a22-860c-4b4a-8a78-530006460ba4: [1,False,RM USLAXA - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 767ce763-3c60-42b7-96be-8c0e407f5500: [1,False,RM USLAXA - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 5cea72ec-d370-4d6a-ab1b-425bbe84d6c9: [1,False,RM USLAXA - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 49a8751a-41d9-4ccd-aace-29265a8eb7db: [1,False,RM USLAXA - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 1b814e9c-2706-4aa4-a105-2cdbc5e670fd: [1,False,RM USLAXA - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 0ff80f3b-a91e-4357-ba86-b339d9a7488c: [1,False,RM USLAXA - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: eaae3178-be80-420b-858d-031a7af23f26: [1,False,RM USJFKA - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: e870ebf5-af6e-4764-a89c-2deab5e9728c: [1,False,RM USJFKA - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: c6efa935-448a-46f5-939e-83672b195102: [1,False,RM USJFKA - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: c6629e65-823e-4048-9877-8bbf1a3e5a77: [1,False,RM USJFKA - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: c548b03d-45ca-4b83-ac8f-205eef8be17c: [1,False,RM USJFKA - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: bfbd81e6-100e-441a-81ea-590a81d3bc3f: [1,False,RM USJFKA - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: a45a07b5-ba2e-4a09-b3d4-5c897c7a6d7a: [1,False,RM USJFKA - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: a2a92676-0f19-4f39-89e7-92dbb4c1de48: [1,False,RM USJFKA - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 8eb695d7-5773-4c63-aec2-76f874fb4076: [1,False,RM USJFKA - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 8b7f596e-f203-4a77-bdb8-711f462c117d: [1,False,RM USJFKA - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 83c0c531-ca32-4cec-802d-2b7ad9fecd3a: [1,False,RM USJFKA - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 764df177-0d69-47e4-9aa1-c8ba495ab412: [1,False,RM USJFKA - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 5a3d2010-0816-4613-9b9e-63afd94312b2: [1,False,RM USJFKA - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 569b232f-fe59-455c-a38b-6e80b9e1cd2b: [1,False,RM USJFKA - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 4702eb62-a473-4bc2-adf7-effb2619480f: [1,False,RM USJFKA - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 2e855f49-0d8c-42a3-aa53-05edfc72bb81: [1,False,RM USJFKA - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 22a236e1-3da8-44f9-b853-f508913641b7: [1,False,RM USJFKA - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 17ddbe7b-0f83-40d8-916d-9ce0beb4ab0b: [1,False,RM USJFKA - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: f9bb4176-4033-4faf-8681-269e8375d79a: [1,False,RM TORONTO-A - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: f0d94469-7c3f-4780-89f7-17bf97b8af88: [1,False,RM TORONTO-A - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: e1c69b5a-2711-4584-bd9a-555395804082: [1,False,RM TORONTO-A - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: e0b9405c-a4b3-43a5-87d1-f98c878c4ac3: [1,False,RM TORONTO-A - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: d9b1fea0-a484-4b02-b46b-99b7c95ac8a5: [1,False,RM TORONTO-A - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: d614a12b-87a7-46ce-93c7-afd837d8e084: [1,False,RM TORONTO-A - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: bc4ac6d1-bd45-4982-8067-00de502afe55: [1,False,RM TORONTO-A - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: bae0caa1-93eb-4be4-a62c-dfdf4a2ff419: [1,False,RM TORONTO-A - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: a318a335-5fba-4df5-adcf-bb2cb3bbefbc: [1,False,RM TORONTO-A - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 8c2431c9-d770-4ee0-9ebb-e5dc8683974b: [1,False,RM TORONTO-A - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 6c10ff57-21d6-4dfb-b397-5a4515284bc5: [1,False,RM TORONTO-A - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: dcd165ec-01f2-4085-9f9b-542ed7725087: [1,False,RM SYDNEY - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: cb5d78e2-bdc6-43ae-b016-7e55ec724c31: [1,False,RM SYDNEY - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: ba02a597-7863-402c-87f5-87cedc62e7d5: [1,False,RM SYDNEY - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: b41fc4a6-837e-4909-ba9d-54399d40ca5e: [1,False,RM SYDNEY - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: b1521865-b4eb-4583-8bfb-fbd5ead6bd42: [1,False,RM SYDNEY - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: af7e76a1-141b-46b6-a8a5-cf04bb40c8ce: [1,False,RM SYDNEY - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: adccd665-00aa-4e72-83ac-aa8b7a291850: [1,False,RM SYDNEY - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 2ae36886-7696-4c1b-9f81-112d2d1a66c5: [1,False,RM SYDNEY - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: f9376c81-d3c8-424c-aa48-f7ab73831c02: [1,False,RM SPAIN - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: a67d5cf9-fcfb-4f8f-91c0-8194cf1eb0b4: [1,False,RM SPAIN - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 9c0f7656-4ac4-4fb3-8656-2808b11f340e: [1,False,RM SPAIN - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 919d9751-bc26-4367-827d-d4964f5344d7: [1,False,RM SPAIN - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 2c6d8e2f-39be-4023-bef8-06c19c4afe55: [1,False,RM SPAIN - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: a428dcb9-c13a-4bec-9ffd-c9cf379f563b: [1,False,RM REST OF EUROPE - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 6b9fad4d-b2e2-4b5f-af82-6cdfa187420c: [1,False,RM REST OF EUROPE - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 536f9023-0696-43a1-ad08-51019e63feb0: [1,False,RM REST OF EUROPE - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 0b490240-d7e4-42cc-a2a0-2399aafd82e5: [1,False,RM REST OF EUROPE - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: d891bcdb-8e2a-4a06-a971-87e61e32e619: [1,False,RM MONTREAL - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: cfd60973-54ba-459b-a6d2-5a9dd753e2cc: [1,False,RM MONTREAL - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 750818f1-0a46-4955-a2d6-4861e4c9801f: [1,False,RM MONTREAL - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 735f16c3-daeb-4167-b39e-a7b341cc030e: [1,False,RM MONTREAL - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 449d79e6-0018-4ec0-ab0b-e204dbc08819: [1,False,RM MONTREAL - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 42ffb822-5e16-4760-b7d8-115d253c058b: [1,False,RM MONTREAL - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 10cf2066-c155-41d6-badb-9a172a521b56: [1,False,RM MONTREAL - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 718962b1-b0cd-4591-bd82-71e364a87837: [1,False,RM MONTREAL]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: f554beb2-ad59-483d-bb55-75e733bcd8d0: [1,False,RM ITALY - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: ce75038a-426a-4655-8752-c802564f20e2: [1,False,RM ITALY - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 9e567a9b-16f4-4c57-9c83-786d1366b956: [1,False,RM ITALY - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 9d8abf88-49de-4066-978c-0f94e778a1af: [1,False,RM ITALY - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 7da61c05-bfe1-4837-b5d1-e8d750b80af9: [1,False,RM ITALY - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 6a338913-66d6-409f-b542-8b7427066360: [1,False,RM ITALY - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 611c46c3-c3ff-49c8-8cc9-6055af127963: [1,False,RM ITALY - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 59f65080-3ecd-44fa-b096-2f1ab1a2c4a9: [1,False,RM ITALY - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 51316976-bf3e-480a-ad33-ddf0f060b381: [1,False,RM ITALY - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 509ee8ea-770a-47d8-a454-188cc82d8748: [1,False,RM ITALY - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 4056d60b-445a-471b-bce6-2db16ef6d709: [1,False,RM ITALY - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 32ae31ae-7331-4777-a637-d5d9e158c001: [1,False,RM ITALY - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 0870a621-0a12-4946-a92f-954beaa132d4: [1,False,RM ITALY - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 07748c81-5348-4465-b8a6-3f551afa3bf5: [1,False,RM IRELAND - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: ff60d13a-2cc9-41b3-ba9a-a665be1fdbc8: [1,False,RM GERMANY - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: f8ba09e7-5f09-413c-9491-025124542c95: [1,False,RM GERMANY - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: dcfa85bc-b9a9-4382-b090-d40f2d207ecf: [1,False,RM GERMANY - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: d8983815-5402-460a-9ddb-472c49f42e0d: [1,False,RM GERMANY - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: cec806f1-0671-4b0d-b922-c004b92b3c70: [1,False,RM GERMANY - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: ce3a00a0-f9e0-4c7d-b663-02485f9b1089: [1,False,RM GERMANY - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: bf692f58-002b-4fa9-9d07-23149b4ad9f7: [1,False,RM GERMANY - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: bd173af2-34ce-4aab-b93a-e7c7d21d3302: [1,False,RM GERMANY - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: bb68938d-b94a-42fc-aa3b-c1207781a44b: [1,False,RM GERMANY - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: adb5b22f-d513-4a7a-8f15-97a21f63d371: [1,False,RM GERMANY - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 9cc03f44-0a25-492b-b59d-c4ae9fd7e30c: [1,False,RM GERMANY - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 993b448f-9ab4-497b-b2d7-1ce338e882bd: [1,False,RM GERMANY - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 94fe3793-0915-4843-9885-1ca33b7b27a9: [1,False,RM GERMANY - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 8e9d9bcb-6199-43c0-a682-81f039b1532a: [1,False,RM GERMANY - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 7f3ee00f-94be-45da-a8ea-5be2ba5ab2cd: [1,False,RM GERMANY - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 784a058b-4a6e-4ec1-9304-5e6caf0db9b3: [1,False,RM GERMANY - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 6b5b93a6-a261-4f0d-8e8f-3900f2b70189: [1,False,RM GERMANY - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 4fb4a868-30c5-4145-a37e-7239202eaa23: [1,False,RM GERMANY - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 42261f78-27d5-42c1-9768-8a98869c543b: [1,False,RM GERMANY - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 41cbd59b-42d9-4076-8aa1-bdbd37f54888: [1,False,RM GERMANY - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 390dc135-0db7-4601-86b2-4cffcf8fe739: [1,False,RM GERMANY - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 35b8e8c3-b5ba-4b29-98a2-d25ae7cfce61: [1,False,RM GERMANY - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 25a43ba8-76d8-4b59-9d36-fd8035dd646f: [1,False,RM GERMANY - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 1a0a105e-323d-493a-a55b-cd496d8afd3a: [1,False,RM GERMANY - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 16397bf2-1430-4f32-92b6-c012c059de1c: [1,False,RM GERMANY - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 136d69ea-a372-46c2-bb82-61d300985850: [1,False,RM GERMANY - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 11c3fa14-b690-4c5b-9dfe-9d23eb753b36: [1,False,RM GERMANY - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 0b2d8874-b265-45c6-be72-38251928d52b: [1,False,RM GERMANY - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 02dc99c7-c1e1-414e-aff1-9443cbe02059: [1,False,RM GERMANY - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: f8020843-9945-4e19-ace2-cd72886b8770: [1,False,RM FRANCE - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: ce725884-385c-4c0a-8928-426a910fb610: [1,False,RM FRANCE - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: a75abd4c-23c5-466b-a308-e6ee070eb81b: [1,False,RM FRANCE - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 91fbc8e5-4727-4e51-911e-1a2b9888e472: [1,False,RM FRANCE - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 78aa6a12-66a2-4d32-be5a-5af4449b093e: [1,False,RM FRANCE - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 74a9c265-c5f4-4680-8080-ae4225b0b7f6: [1,False,RM FRANCE - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 6ac05486-768c-40a5-8766-8f0495060cb1: [1,False,RM FRANCE - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 567e6620-8f47-4068-abb7-0f9f7d318b8d: [1,False,RM FRANCE - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 5630edcf-c7b2-4f3c-9361-db28f5bd7337: [1,False,RM FRANCE - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 55359202-2db5-429e-9ebb-8b04681ff839: [1,False,RM FRANCE - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 42c74b35-40c6-4be6-923f-76023e897086: [1,False,RM FRANCE - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 3db77550-932c-4aab-8780-1986b631a102: [1,False,RM FRANCE - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 30738c2b-2e4d-4182-b3db-3ad0c7316eb6: [1,False,RM FRANCE - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 268e727f-0f0f-4b10-8d3e-b3e79c7dde8a: [1,False,RM FRANCE - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 0fea7c72-731a-448a-b55f-297fef4e2eaa: [1,False,RM FRANCE - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 000b1b60-647a-4a79-ac46-6c6b1e8bd900: [1,False,RM FRANCE - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: df916b12-8195-4541-9bc0-fa5d37fcbb7d: [1,False,DPD Two Day - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 9ee344bd-0e78-4776-9f5d-bcbbb85ac6c0: [1,False,DPD Next Day - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 9a2b2898-b90e-4736-ac33-c3b0c4700e02: [1,False,DPD Next Day - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 067b7bcf-d78d-4860-b658-75243a434acb: [1,False,DPD Next Day - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: ff84197b-e536-4117-883a-bcf87e073a7c: [1,False,DPD Classic Expresspak - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: cdb797c7-867c-411a-9b67-f5e15109d102: [1,False,DPD Classic Expresspak - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: c46952ca-19fe-4e4d-b228-fcb79aeab4d0: [1,False,DPD Classic Expresspak - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: b8f3cc71-4819-4519-b4cd-03bd1f54d3ac: [1,False,DPD Classic Expresspak - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 87b7d72f-1def-49fc-b443-9d5ea5022fec: [1,False,DPD Classic Expresspak - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 860b4936-031c-47e3-a446-637962127e41: [1,False,DPD Classic Expresspak - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 7fb4b931-56ae-47ff-908f-83c973163abb: [1,False,DPD Classic Expresspak - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 7dedd79a-f02c-47a4-8033-63b483221fe5: [1,False,DPD Classic Expresspak - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 70dac18d-9152-4af7-a45f-3cc00d0ba81b: [1,False,DPD Classic Expresspak - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 652fd3c3-a2b5-4588-bcd2-e1b9e78cb8b3: [1,False,DPD Classic Expresspak - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 625a3390-cab4-4426-ba68-a90946369a78: [1,False,DPD Classic Expresspak - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 565d7b9f-f164-472f-b0b9-4d8975a9f9a6: [1,False,DPD Classic Expresspak - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 56198c73-5de3-4110-8a23-555347e367ad: [1,False,DPD Classic Expresspak - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 3de97972-b9da-4138-8c57-d7004d2efdde: [1,False,DPD Classic Expresspak - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 268710af-0a4d-4be1-b39e-de9019665560: [1,False,DPD Classic Expresspak - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 1df40278-6fe6-45e1-9684-d0438a695b93: [1,False,DPD Classic Expresspak - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 046aaef3-4ad2-4898-90e6-e0c8eda7885c: [1,False,DPD Classic Expresspak - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: ef00e9de-a80e-4154-a205-3e19cf3a474c: [1,False,DPD Classic - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: eefba6dd-abd1-403b-abe4-5a54c7f62150: [1,False,DPD Classic - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: d96b6524-bc92-4c0a-a883-be31f899963e: [1,False,DPD Classic - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: d52c27b7-c077-49b2-945e-5b985fcd5a0e: [1,False,DPD Classic - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: d3644de3-1c37-44f9-99c3-881f299ec74d: [1,False,DPD Classic - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: d26ef10d-558f-427d-a2c3-ff29ac2f6338: [1,False,DPD Classic - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: d138183a-5b41-4053-9283-17779217678c: [1,False,DPD Classic - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: d1047b2b-9f0d-45fa-8e86-1f175cfa43c6: [1,False,DPD Classic - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: d0520844-babb-46de-aed1-8da82917ecd2: [1,False,DPD Classic - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: cbd3b004-7256-458d-a93d-acf01495cedc: [1,False,DPD Classic - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: c4f85ab8-8893-4507-8b43-1a55e2aec07e: [1,False,DPD Classic - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: c38c9491-d2e9-4cc0-9ebb-71e75e3d9e29: [1,False,DPD Classic - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: bbfb3134-cbc6-414c-b411-14f03b501b9a: [1,False,DPD Classic - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: b90921fb-55df-448b-82ca-5c704f38c989: [1,False,DPD Classic - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: b868edea-91fd-4c81-a257-7dd7a050425a: [1,False,DPD Classic - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: b5a762af-6dcc-4681-af59-4bdd360ff27f: [1,False,DPD Classic - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: b1d8903e-0e58-4d15-84fc-f5d893dc87dd: [1,False,DPD Classic - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: adab7fbf-babd-430b-8651-3b2a1074145b: [1,False,DPD Classic - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 9bdc0514-845f-4b6a-af83-80e1773bc94a: [1,False,DPD Classic - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 9a48b4b8-e600-44c4-b8a4-53fa93aaaf63: [1,False,DPD Classic - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 991a180c-85e4-4d77-be13-9439233be9c0: [1,False,DPD Classic - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 990d6606-69b5-4247-b9f9-a7f84cbcb057: [1,False,DPD Classic - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 91e5a70b-1926-4c8a-be48-9d736f574ce8: [1,False,DPD Classic - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 90abf2f5-2927-4b9b-a50e-47e76150fc4f: [1,False,DPD Classic - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 8e43f589-d838-4de6-8473-3d78a9ecb7cd: [1,False,DPD Classic - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 8cf2475e-4fb5-4563-b9cf-d79e9cb06a2a: [1,False,DPD Classic - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 8496b87b-be69-4475-8a5c-4b80cb6d334c: [1,False,DPD Classic - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 82aba3a7-068d-4eff-898f-59fc3783669b: [1,False,DPD Classic - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 82a6ff6c-ccc7-456e-9e70-867283eabc79: [1,False,DPD Classic - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 7dbe183a-acef-4383-8caf-71449e6cf769: [1,False,DPD Classic - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 7c973fc3-54c0-4434-8562-98b63b0c6c1c: [1,False,DPD Classic - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 7a4c64a3-1522-4044-b8d7-88076a8971c7: [1,False,DPD Classic - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 756ff103-1ac1-434b-a78b-8303a9d4a6eb: [1,False,DPD Classic - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 71efc5f3-558d-4e50-8f1a-0ce18ee07bef: [1,False,DPD Classic - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 700b7ac3-d190-4139-9076-4da9e4068004: [1,False,DPD Classic - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 6dc72da3-84f5-45eb-9db5-52c9e10ac5c0: [1,False,DPD Classic - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 685200a1-a695-4a81-9115-e5a8660ce8aa: [1,False,DPD Classic - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 5c3d4c5c-9eb1-4bc2-8aed-c2d0fb20afb0: [1,False,DPD Classic - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 54adbd00-b1ee-4ee9-9fc9-4262dcfde829: [1,False,DPD Classic - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 4bfe3f0f-8503-471e-a729-7a2bbd2597e4: [1,False,DPD Classic - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 424a9953-b7b9-446d-9e5b-10a19ff41978: [1,False,DPD Classic - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 40b8dcd4-9a45-4dd4-abf6-0ffbcfa439b3: [1,False,DPD Classic - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 4083624b-2a07-45f4-8007-ee172dc5fa92: [1,False,DPD Classic - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 3ed3c831-94f3-4344-8e1c-be0cbe21b4eb: [1,False,DPD Classic - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 1da99bc4-d85b-4387-8dd6-dd574e259052: [1,False,DPD Classic - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 1c162d64-e9c8-474f-bf96-3caf2469feeb: [1,False,DPD Classic - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 13a506ab-bf13-4b0d-8518-940d275033f3: [1,False,DPD Classic - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 0f6e0e74-1189-4409-873e-d2e0cbae8c6f: [1,False,DPD Classic - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 05aba421-033d-41c7-bfe1-bbc650e913d5: [1,False,DPD Classic - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: f49bf874-0db1-41e4-9450-6c2c02f4ce96: [1,False,AMZ - One Day]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: f3c67464-daef-4c13-8d85-2943625a8ead: [1,False,AMZ - One Day]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: dfcb130a-eec7-4793-ba27-9d586abb9e89: [1,False,AMZ - One Day]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: d8ecae93-6070-400c-8de6-6430a6179902: [1,False,AMZ - One Day]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: d11ba35f-6564-4a29-8294-efe9d0d36528: [1,False,AMZ - One Day]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: cdf23ba3-233d-4573-a538-04eefa8a25cf: [1,False,AMZ - One Day]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: cc03922b-d324-4aae-a9ef-216adf8760bc: [1,False,AMZ - One Day]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: cbccf400-46d7-40ca-8a77-35258e656bc4: [1,False,AMZ - One Day]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: cb84bb96-8c23-46f8-973d-bd1058f84300: [1,False,AMZ - One Day]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: c97df469-be62-4141-8cf4-a9c9ba6d3151: [1,False,AMZ - One Day]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: c77df67d-574d-47ca-83fa-36284ca074c3: [1,False,AMZ - One Day]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: c227b3fa-0071-4a5a-9ae3-78f917e57dce: [1,False,AMZ - One Day]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: c0326fc7-ef54-44d1-ad61-c81bd7b9d345: [1,False,AMZ - One Day]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: bd7b20de-3eb3-4ced-8b1a-e42c2d8bff71: [1,False,AMZ - One Day]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: bc27142e-afc4-46d1-92a2-930125826097: [1,False,AMZ - One Day]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: b343c596-a195-46d6-9ad9-07616c27a706: [1,False,AMZ - One Day]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: ae1fcc7a-b8f2-4322-af09-bdc60ac42a9e: [1,False,AMZ - One Day]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: a26d7096-9f45-4684-8e1c-98b31e5b7880: [1,False,AMZ - One Day]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 9711c60e-b722-4abc-8633-73eb16746c99: [1,False,AMZ - One Day]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 91ec16ee-7806-4dda-af43-651111728752: [1,False,AMZ - One Day]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 8f16e1ca-5041-46c3-9e46-40524aaf9bef: [1,False,AMZ - One Day]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 8d643d02-ab4f-4d9b-8fb0-6f820f6d25ff: [1,False,AMZ - One Day]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 867c1e52-8c72-460d-8b18-a52ec07916b1: [1,False,AMZ - One Day]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 82cb9f2b-8042-41b8-8bcc-d7dfa56aedc2: [1,False,AMZ - One Day]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 7d6f6404-4ab8-414a-98de-7cc50428fedd: [1,False,AMZ - One Day]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 7d541c72-bc87-4617-b191-e8687dd95d02: [1,False,AMZ - One Day]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 7885c2e2-de1e-4794-9c9e-2dfa6d3dfd10: [1,False,AMZ - One Day]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 774070d2-248b-44ad-97fa-fd8c6607562b: [1,False,AMZ - One Day]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 75a2f269-2477-40d0-a984-d5bf0833e8bb: [1,False,AMZ - One Day]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 71ccbb36-cd8b-46a8-aa72-92ec3fb741fc: [1,False,AMZ - One Day]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 7160b093-cb80-4454-9026-82682b8c0430: [1,False,AMZ - One Day]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 6be21c23-9bae-4c93-ab45-c78fec532f8f: [1,False,AMZ - One Day]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 69b5b444-1a4c-4e7f-82a7-55ef82dfa2ae: [1,False,AMZ - One Day]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 69b18b34-00f7-415d-9ecc-093a2c270545: [1,False,AMZ - One Day]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 640008ad-baac-4ab5-be45-be4fac34f6db: [1,False,AMZ - One Day]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 63ef01f1-e82a-4c7e-945c-a0f7c0f935f3: [1,False,AMZ - One Day]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 5c31abc2-941f-4645-9046-4511237a1a6b: [1,False,AMZ - One Day]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 5b59d53d-f519-4519-833e-c102da0811e8: [1,False,AMZ - One Day]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 5488101b-4b3d-4874-9793-e59cd3e47c61: [1,False,AMZ - One Day]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 4f81a35e-f23c-4163-88ba-4ea71bb3d10b: [1,False,AMZ - One Day]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 4dd4d120-0e76-47d5-92d0-517c7c388ec2: [1,False,AMZ - One Day]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 4d7055f9-c2f8-4ab1-924c-6a22ebc4802e: [1,False,AMZ - One Day]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 48b0f4df-cbf3-427d-8ee7-0beb8ebe2c0d: [1,False,AMZ - One Day]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 3de3d86f-8c4c-4f45-90c1-1ab076e79940: [1,False,AMZ - One Day]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 38d78fa7-7e60-48e3-aafc-2f5d7455ebc5: [1,False,AMZ - One Day]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 3056712b-ad4b-4658-a088-44d2ebdb0b2a: [1,False,AMZ - One Day]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 2e2b9a50-e2d9-4286-a809-c4ca41c8304e: [1,False,AMZ - One Day]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 242fc9ed-f2c5-48da-91c4-0350f68338ef: [1,False,AMZ - One Day]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 22fc17a8-d9cc-41c9-9fe1-968f8d396296: [1,False,AMZ - One Day]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 1c130853-f4e4-4ebc-8185-3e46c2388c6b: [1,False,AMZ - One Day]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 19d8f58b-99bb-43a5-9092-331ed2a0c4f9: [1,False,AMZ - One Day]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 166175b3-e6a5-4ad0-ab47-e64acbefd3e5: [1,False,AMZ - One Day]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 152d3922-7f69-4de1-b9bb-0d1727ce479e: [1,False,AMZ - One Day]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: fe977255-e925-442e-8118-c63ada99c91a: [1,False,48T - PACKET - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: fe838959-2f44-4dbf-bd53-e85533919ae1: [1,False,48T - PACKET - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: fd5a17a5-7aa3-4e63-a5dc-5640b031a9d0: [1,False,48T - PACKET - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: fce581c1-553b-4960-90d3-30cd39ac4e5a: [1,False,48T - PACKET - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: fc062024-b0fd-4b20-845e-1794128e41f0: [1,False,48T - PACKET - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: f9862340-5670-40f2-8741-f51e6d0b29c5: [1,False,48T - PACKET - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: f5cece49-f03e-453f-be0b-56a179222763: [1,False,48T - PACKET - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: f403e954-42d7-4d3e-acf6-344b07fbd457: [1,False,48T - PACKET - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: f2fd0820-2f30-448e-9399-48ce2873c39a: [1,False,48T - PACKET - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: f1d46a43-1190-47cd-9d07-2380aba41ba7: [1,False,48T - PACKET - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: ef62b4ac-5427-419c-abd5-173aa16f4e7a: [1,False,48T - PACKET - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: ee458f34-0014-4828-aed6-42d8bf786832: [1,False,48T - PACKET - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: e92eac93-bc38-4ab6-8280-0883721631af: [1,False,48T - PACKET - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: e8f443da-ef54-49be-b471-f5f727f009f5: [1,False,48T - PACKET - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: e5921012-b3a0-4dae-bba4-20807a3a8474: [1,False,48T - PACKET - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: e051a3b4-2021-4d7c-be26-b7caac64f7b3: [1,False,48T - PACKET - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: dfe8afb2-bd5b-4ba5-b444-634daa826b06: [1,False,48T - PACKET - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: df6acf3d-95d0-409d-a232-4bdeb3ae520d: [1,False,48T - PACKET - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: dc3ec536-3ab7-4f6a-982b-0e5224c55fef: [1,False,48T - PACKET - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: dc06a797-3415-4a0f-ba0a-0325dd6dd909: [1,False,48T - PACKET - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: d8f03863-cfee-4602-9124-ebed405fba5e: [1,False,48T - PACKET - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: d7b100ec-ebd7-491c-aab1-74f2b2b62176: [1,False,48T - PACKET - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: d736e339-ab2d-4196-a728-6bcc209d0b55: [1,False,48T - PACKET - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: d5ab5844-ec56-47cf-b4bd-384d582073b6: [1,False,48T - PACKET - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: d0af9e6a-a42c-46b7-a2e6-bd90a7b4cb15: [1,False,48T - PACKET - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: cf285d25-c7f2-45ac-b2f9-06251eb7b109: [1,False,48T - PACKET - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: ce94327b-bd0d-421c-b03c-f6aa99abd1a6: [1,False,48T - PACKET - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: cb5427b3-874a-4ae8-be1d-c7d35aec545d: [1,False,48T - PACKET - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: c97cc282-7f93-4377-96d8-f7d10076a614: [1,False,48T - PACKET - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: c746b42c-6bf2-40a1-a75c-2683c8f6165d: [1,False,48T - PACKET - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: c6d4bb7b-62ec-4980-b3c8-562b9697dc22: [1,False,48T - PACKET - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: c69114d1-b29b-4343-8615-eaf275792186: [1,False,48T - PACKET - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: c5af8728-d4c9-4746-85ce-454c16fada70: [1,False,48T - PACKET - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: c2a1833e-310b-4a36-92c6-e70f0d4f5870: [1,False,48T - PACKET - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: c0a581a2-9490-468a-b9fb-b7025092d471: [1,False,48T - PACKET - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: beddbaaf-6602-42fb-94fd-5a29fa80a081: [1,False,48T - PACKET - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: b945daaa-94fb-4657-8c89-21f7b2a7dd29: [1,False,48T - PACKET - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: b7f8d52a-a485-4f8e-a4c4-f120d733cfb8: [1,False,48T - PACKET - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: b77a0b59-77d7-4997-9b3f-f8a46a9cc386: [1,False,48T - PACKET - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: b7650cd7-45a0-451a-a650-7bf6acc6ac3c: [1,False,48T - PACKET - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: b75217cf-b30a-4df7-9be4-b27cbca70801: [1,False,48T - PACKET - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: b6e16545-23cb-4723-acc3-89a8be05deb2: [1,False,48T - PACKET - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: b43ea115-a0ad-4472-883e-47faff5d13a3: [1,False,48T - PACKET - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: ac668614-81bd-4f04-b135-2e2a2a6aa1b9: [1,False,48T - PACKET - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: ac4ab5a1-b81b-481f-9005-bc83a515204e: [1,False,48T - PACKET - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: ab4e4aa2-30b2-4d86-a5dd-c57c9d090678: [1,False,48T - PACKET - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: aa9af5f6-2e27-4425-8b06-4a875b4a6e2b: [1,False,48T - PACKET - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: aa73b703-fa3e-44ed-9ef1-656aac0fe865: [1,False,48T - PACKET - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: a6f82dc7-d40c-4c3a-a543-3f99cad57def: [1,False,48T - PACKET - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: a3dcafb7-5746-4a96-9d70-6d38f9654873: [1,False,48T - PACKET - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: a0fd35ea-fdd1-44f2-8c3e-0bcb22c9bfb8: [1,False,48T - PACKET - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 9e349215-ebab-4ae4-97b7-a7bbeb083eda: [1,False,48T - PACKET - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 9e0ef1e9-9d0a-4a85-8559-edbf2242ed94: [1,False,48T - PACKET - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 9bc3805c-f9bd-4c63-a6db-7f3c8ad142db: [1,False,48T - PACKET - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 996d1e50-d060-4746-94d4-94f5db542410: [1,False,48T - PACKET - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 988f8023-cb82-4a08-904a-68da954b78ff: [1,False,48T - PACKET - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 94d97676-7572-4f84-9f9b-23ec93e46d0a: [1,False,48T - PACKET - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 94bbd274-bf94-4f00-8a37-06538f4f4c14: [1,False,48T - PACKET - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 94b04203-959b-4bcc-95ea-73c5780d8fd5: [1,False,48T - PACKET - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 90f8a86f-fbbe-4735-b40a-b1bc697ae9e8: [1,False,48T - PACKET - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 8f17188a-b13d-470b-8a89-5ad3c2943553: [1,False,48T - PACKET - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 8d7e006f-c98b-4639-a2d1-e547c8953c64: [1,False,48T - PACKET - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 8d3f1fbc-e620-481d-8b84-bb108ddcb16e: [1,False,48T - PACKET - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 8c6d3b20-31f0-4a8f-8a7b-c0d706754b51: [1,False,48T - PACKET - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 8b469361-670f-4494-a8f4-4ede4191ce0d: [1,False,48T - PACKET - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 8a74dc7d-2d00-4b73-9f9d-5dfb4cd40881: [1,False,48T - PACKET - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 8a39bcb1-9475-4135-9af4-04119ec2fad8: [1,False,48T - PACKET - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 891233d2-d81c-4745-9911-d46801621a06: [1,False,48T - PACKET - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 866012c0-dc49-4f0f-9591-b34be96ce89c: [1,False,48T - PACKET - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 81771f3d-0c6b-4406-8f43-c7e6c8bbb3c8: [1,False,48T - PACKET - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 7fcdac30-bd4b-4c36-89a2-ee497f409a6e: [1,False,48T - PACKET - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 7c93b51c-6681-4e06-8a87-e81a55b51ba8: [1,False,48T - PACKET - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 7b2dba17-943e-4a2c-9505-6f3882c7e950: [1,False,48T - PACKET - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 7983a807-8273-43f3-ae2c-15e14a705c87: [1,False,48T - PACKET - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 7980db2e-f844-4ba3-9556-8bf3a70b882b: [1,False,48T - PACKET - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 71eb32c0-c2c0-4743-b459-7ee725be4f6a: [1,False,48T - PACKET - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 6ffded40-4035-422a-ab67-f01b3c346d00: [1,False,48T - PACKET - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 6fe93921-73c6-46d7-a916-a174643a9ea0: [1,False,48T - PACKET - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 6fbb74bb-3e39-4ea9-b7e2-c15691d67d29: [1,False,48T - PACKET - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 6e432f91-4a45-4a9a-82d8-d12a4b78a762: [1,False,48T - PACKET - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 67e2cbe3-0bf0-458e-b649-84f047d16551: [1,False,48T - PACKET - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 66c76761-7be5-4795-a1ae-35958b76e0b7: [1,False,48T - PACKET - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 6608b055-8e25-44dd-869c-db56ecc3151d: [1,False,48T - PACKET - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 6472f20e-fcea-4320-9e42-2381f9eaad3a: [1,False,48T - PACKET - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 62c7b340-7eb4-46c1-98f5-e983d2304db4: [1,False,48T - PACKET - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 5eeb65ed-b083-49d7-8504-fd1498df3f8a: [1,False,48T - PACKET - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 5e8b0b98-056b-4cd2-b744-256e5e785497: [1,False,48T - PACKET - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 5e63f102-d4dc-4100-a52b-f75a4057e3c9: [1,False,48T - PACKET - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 5d29dcae-0617-484b-8230-1b8c0f5800a3: [1,False,48T - PACKET - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 5bf7dedb-14de-4d42-9b67-8e2301939bdb: [1,False,48T - PACKET - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 597c7f97-259e-4ad5-bc35-3a86b5b00cd5: [1,False,48T - PACKET - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 58a80a40-b54f-458d-b318-35566973d7ed: [1,False,48T - PACKET - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 5544d2b6-aa2b-4021-8ba3-d7a9f0ba1d2a: [1,False,48T - PACKET - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 5307f9dd-2706-4089-a3b3-64ed361b2193: [1,False,48T - PACKET - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 52faa4c9-039c-43e0-ae66-8b79e1fee354: [1,False,48T - PACKET - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 4f56c13f-b224-4a05-8a5a-3a2617fe3b6a: [1,False,48T - PACKET - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 4b610cf9-c93f-4b10-bb2f-29c21e962777: [1,False,48T - PACKET - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 47b3dd7e-8637-440f-bed7-56b35e273c71: [1,False,48T - PACKET - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 46477c12-936e-4a46-8b03-14d534f7c403: [1,False,48T - PACKET - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 45c50e41-d97d-47e1-bf79-435008ad3bda: [1,False,48T - PACKET - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 457a7145-4523-4a13-81f6-2cc0096eda61: [1,False,48T - PACKET - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 44ca680a-c826-4f35-945c-07e52c2d141a: [1,False,48T - PACKET - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 443ce045-c2b9-4e33-b680-964e8875ac71: [1,False,48T - PACKET - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 4069355e-e876-4ff9-8c01-acd6d5142fc8: [1,False,48T - PACKET - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 3d53869f-8189-4bba-b2bc-762150aea2a3: [1,False,48T - PACKET - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 3cb073c2-d468-47d4-b121-884b0a5c8759: [1,False,48T - PACKET - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 38cc75a3-ffb2-43ae-8f9f-7e28d3dec82c: [1,False,48T - PACKET - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 37c3eb61-5e87-444c-9e08-bec40d235012: [1,False,48T - PACKET - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 35cde69a-2aab-47f9-858a-67f54ffc0270: [1,False,48T - PACKET - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 3445a450-bffc-4cf6-930d-4b529769be6d: [1,False,48T - PACKET - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 2fafed13-237f-42d7-a6ae-df0875549168: [1,False,48T - PACKET - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 2e7a1715-8f2f-4fdf-a00a-b4552bc04b8d: [1,False,48T - PACKET - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 2c2852cc-bc8b-4fc1-ad0a-16d71fb1afc8: [1,False,48T - PACKET - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 29726c4e-828f-4c82-9b02-0d395f4a7cd4: [1,False,48T - PACKET - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 291eb578-b88e-4fc2-9a13-f1dd1c9242cb: [1,False,48T - PACKET - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 282e9ee1-24cb-4c59-8ab9-120d88537861: [1,False,48T - PACKET - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 24e3fe30-4fc1-4478-9215-4974f59e10a0: [1,False,48T - PACKET - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 22d647d3-5afd-4e0d-8a41-9adba9fa2998: [1,False,48T - PACKET - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 1fd7ad20-b215-4300-ba41-9803c7ec433f: [1,False,48T - PACKET - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 1f79d75e-e6fa-4108-8b3d-17e8d0752902: [1,False,48T - PACKET - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 1e4be546-e707-4ae0-b583-037eee127b6e: [1,False,48T - PACKET - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 1d68c4ba-457f-403b-b397-55525d664853: [1,False,48T - PACKET - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 1b2932eb-2b0d-4ace-ad05-33bf271eb01d: [1,False,48T - PACKET - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 1311d166-ae5e-4d2b-b24b-360ab6d56fa0: [1,False,48T - PACKET - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 10ed79c9-bf2e-4d10-8bf7-13a7240d127c: [1,False,48T - PACKET - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 0e75f49b-8d60-4bf9-90e2-9f54e6df42c5: [1,False,48T - PACKET - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 0af51d2a-b472-4558-97fc-b7aa371bc1b4: [1,False,48T - PACKET - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 097153e1-09d2-446d-947c-7a75a686da7e: [1,False,48T - PACKET - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: fefbaba4-d110-4315-ab59-f10cebb27505: [1,False,48T - AMZ - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: fe74a90f-b94f-4af3-b565-c99ccb788d67: [1,False,48T - AMZ - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: fe12eee7-d8b5-49e7-ba53-6e063057d111: [1,False,48T - AMZ - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: fd9d80e1-5bbe-43e9-9374-a462c5912f13: [1,False,48T - AMZ - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: fc4992b9-2857-47d3-a241-1a994ad047ca: [1,False,48T - AMZ - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: fb9a6bed-4f3c-45c2-967f-e0600e6a09ed: [1,False,48T - AMZ - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: fb99fd40-f0c4-4192-ae87-9ffcf984fe49: [1,False,48T - AMZ - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: fb8393ea-db54-4fbb-8452-c3cb196440d4: [1,False,48T - AMZ - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: fa5f7375-9c6f-4932-9de0-628ed31723fe: [1,False,48T - AMZ - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: f9214b78-be46-410a-9398-4bf880092818: [1,False,48T - AMZ - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: f88c937a-4455-4413-a484-94bb45858166: [1,False,48T - AMZ - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: f7e00aa1-6f6a-40c8-a138-e9affcb637bf: [1,False,48T - AMZ - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: f5751450-0f0f-4f85-85fd-49a608d3c6f7: [1,False,48T - AMZ - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: f4dddd29-a124-4cfe-954f-5c1fdd09d8ee: [1,False,48T - AMZ - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: f4bead9a-b6fb-43a8-b225-f13d6909aa40: [1,False,48T - AMZ - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: f49b78ab-612c-4bb3-8390-91129e0af381: [1,False,48T - AMZ - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: f33e886b-a674-48d1-99fd-51dfbf481c85: [1,False,48T - AMZ - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: f268f4e3-c47b-441a-a17b-ba83b2d393f8: [1,False,48T - AMZ - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: f1ec2908-3d10-4995-82e9-f1924f67c6eb: [1,False,48T - AMZ - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: f1b1f481-f5b2-4305-abaa-3399ebdb06d8: [1,False,48T - AMZ - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: f129c14d-081a-4856-b202-d9b8af7a4b31: [1,False,48T - AMZ - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: f0f82f54-ea83-4c35-8647-47b40ed1dc14: [1,False,48T - AMZ - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: f00c32bd-3b35-45e1-b8bb-b891d37e4a44: [1,False,48T - AMZ - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: ef695a25-d229-445d-9cbb-8322d056a620: [1,False,48T - AMZ - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: edb6a232-ca3d-4931-b080-f192921b7da4: [1,False,48T - AMZ - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: eb61bb3e-6b77-4d7f-b82d-93c97ba72f04: [1,False,48T - AMZ - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: eb424011-9e21-4b24-9e91-9f36da9b0ed6: [1,False,48T - AMZ - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: e9dfd1bc-9c70-4c53-b333-51e825ac8678: [1,False,48T - AMZ - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: e95bb130-69f9-46b6-bf2b-90eb5bd36717: [1,False,48T - AMZ - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: e942ebb2-bea7-4537-91ba-a0d3868e8d39: [1,False,48T - AMZ - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: e91a3ca4-097f-483a-b351-e6859f71f05c: [1,False,48T - AMZ - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: e690c17c-2d4a-4ae1-aa19-df4379d566bc: [1,False,48T - AMZ - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: e5fcb839-a812-4c7b-97b0-f546b9ac49c9: [1,False,48T - AMZ - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: e3dc270a-adf1-47bc-8499-ed5ddbc9a7ca: [1,False,48T - AMZ - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: e2513f79-7df8-4531-96b6-21b7dd86f859: [1,False,48T - AMZ - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: e1ba8e07-528b-468c-b7d0-923657993165: [1,False,48T - AMZ - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: e11fd6ab-d954-4a3f-96d2-3dd8c58cd442: [1,False,48T - AMZ - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: e0a2c5b9-efa5-438f-a501-37b48c7fc7f9: [1,False,48T - AMZ - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: de68b32b-925b-4577-9dff-876b7ef0805e: [1,False,48T - AMZ - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: dd727751-39c5-4528-b4af-50450c6d93e7: [1,False,48T - AMZ - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: dcf6b836-8903-406a-b339-198a19b5b427: [1,False,48T - AMZ - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: dc7b2753-5afd-4a29-837d-ae7bcf818bd6: [1,False,48T - AMZ - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: dab904bd-e9c9-4d9e-a082-e5826949a125: [1,False,48T - AMZ - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: daa3261c-42a7-491c-8a5c-09ea569c9f1a: [1,False,48T - AMZ - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: da001a73-4f79-4307-8647-ad6c2bd3957d: [1,False,48T - AMZ - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: d9eb2bd6-f341-4bfd-9c5b-07cf2f025c8f: [1,False,48T - AMZ - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: d985ddfd-a008-4305-985d-24000175b086: [1,False,48T - AMZ - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: d961321c-2fb1-4e05-a7ee-1a7017c8ad41: [1,False,48T - AMZ - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: d85c886e-8e57-47a5-8a6c-fd8555fa4d4d: [1,False,48T - AMZ - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: d72fedb3-9b0e-45f6-8486-891d9fd2653c: [1,False,48T - AMZ - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: d70a8b30-b5e5-45e4-a248-d619b72a1dbf: [1,False,48T - AMZ - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: d60344ed-6018-472a-86e5-81cf82900607: [1,False,48T - AMZ - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: d5029e68-44ee-49ba-923b-18aa3f2350ff: [1,False,48T - AMZ - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: d4265a52-4497-4242-aecc-1562fa7846a2: [1,False,48T - AMZ - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: d416b833-8e9f-4f52-b180-a7dfe23d875e: [1,False,48T - AMZ - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: d324b089-cfe8-496c-813c-3cb5fcc05573: [1,False,48T - AMZ - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: d2870c5b-1dee-4bf1-bdae-9e2b7616a6b3: [1,False,48T - AMZ - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: d1bb729a-af63-46de-becd-ceec82be1be7: [1,False,48T - AMZ - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: d1b9e550-5521-4d32-b20d-0564da753a45: [1,False,48T - AMZ - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: d173fdba-b39f-4097-ae4b-508a57b922bd: [1,False,48T - AMZ - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: d13173c0-47c7-49cb-a85d-b577adcfaf4b: [1,False,48T - AMZ - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: d05e46c9-8f87-41ae-af30-92ffd17685cf: [1,False,48T - AMZ - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: cc951144-9732-41b3-acd5-12d245aa866d: [1,False,48T - AMZ - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: cbdbbafd-e8ce-4a21-a301-20b53b198261: [1,False,48T - AMZ - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: cac2498f-5343-4900-ac8b-c4a0e2ebe07d: [1,False,48T - AMZ - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: c9860c5d-bd42-4294-8194-198b68055949: [1,False,48T - AMZ - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: c8bf53fd-aef0-409e-84be-2dae85c62b80: [1,False,48T - AMZ - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: c85ed7d1-c56d-4f5c-89ff-0c4c60ee7ee5: [1,False,48T - AMZ - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: c695df03-3a02-4adf-87de-f91f9130220f: [1,False,48T - AMZ - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: c563ac2b-bb22-4bb6-b117-091a0f9cef60: [1,False,48T - AMZ - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: c4670360-138a-41bf-bbf7-1f6c65d9558f: [1,False,48T - AMZ - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: c4004d0c-0ce5-486e-8fb9-d23f44a5ce14: [1,False,48T - AMZ - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: c3606676-53a0-4067-bb4c-5c0d2d228e8f: [1,False,48T - AMZ - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: c2cd363d-d35f-4d0e-90be-841378cd0856: [1,False,48T - AMZ - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: c17c7529-9786-48ff-ace8-00cd83e02996: [1,False,48T - AMZ - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: c0748ec1-98f0-4925-a7dd-1762d00b0668: [1,False,48T - AMZ - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: c02b24ae-d550-4d76-8c41-0a9f9c9329f0: [1,False,48T - AMZ - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: bfda0808-4246-4e68-85ae-aff831b76754: [1,False,48T - AMZ - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: bf763189-d241-4e4d-8af5-a5dcf009a579: [1,False,48T - AMZ - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: be8b7919-b8f9-4eaf-94c9-22d428862af0: [1,False,48T - AMZ - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: be883846-f0ac-40de-b367-a3faf321a055: [1,False,48T - AMZ - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: be5cbf8a-1039-43c7-b318-1845070fe624: [1,False,48T - AMZ - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: bd9a1279-0d9f-4301-a905-2f104780760b: [1,False,48T - AMZ - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: bd1225bb-46f0-419a-9b08-b5c5086b3674: [1,False,48T - AMZ - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: bbef5e6d-a18f-46d6-94ea-64e402458f8f: [1,False,48T - AMZ - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: bbc51da0-80c0-487f-a4c1-0aa05cd88501: [1,False,48T - AMZ - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: bb9da95d-653e-4ad4-bae6-0bc6bcce09a6: [1,False,48T - AMZ - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: b9b3b6fb-9af7-447e-96a5-a0cf7ebedb33: [1,False,48T - AMZ - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: b7f65e42-dc5c-43e3-a7e9-bd2888ef142e: [1,False,48T - AMZ - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: b648609a-443e-48a7-aca7-581d8397c94c: [1,False,48T - AMZ - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: b636a0a6-d3fc-4753-a344-e9b6c9f7f3f6: [1,False,48T - AMZ - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: b53fcb18-284c-4058-bd3c-f7e2243dbc3e: [1,False,48T - AMZ - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: b208d7db-8380-4f5d-ba91-ce43100c43e8: [1,False,48T - AMZ - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: b0de3534-602d-4eda-9453-dabe2aad4e68: [1,False,48T - AMZ - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: af486aee-61d8-47e5-b3d5-1f95fe25c4f6: [1,False,48T - AMZ - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: ae46f09b-2b5c-4c86-9406-b9a24de5c15d: [1,False,48T - AMZ - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: ae02860e-594d-42c4-9529-5f5ef53d0394: [1,False,48T - AMZ - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: ac9420e4-4645-44c6-96cd-28f5d8361b74: [1,False,48T - AMZ - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: ac38b4f8-eb29-4121-9bf9-ac5e1290e962: [1,False,48T - AMZ - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: abca20fd-ccdd-4e07-809f-7f7e35bca140: [1,False,48T - AMZ - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: a9a94122-dbfc-42a7-b39c-666b74df98eb: [1,False,48T - AMZ - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: a8d3175a-ce20-4132-8a4c-cb406de55f95: [1,False,48T - AMZ - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: a53f2782-5ad7-4938-b522-fb5433471473: [1,False,48T - AMZ - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: a533a67b-c440-451e-9661-f26a35736c2d: [1,False,48T - AMZ - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: a5214635-1412-4b2e-8904-39477be40369: [1,False,48T - AMZ - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: a39c8ed7-e585-4809-8314-a41ec995aaa6: [1,False,48T - AMZ - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: a3790182-26d6-4e7e-8013-ad7ce5c554d9: [1,False,48T - AMZ - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: a2b70450-08b7-4a67-9c84-0c20a9a20a36: [1,False,48T - AMZ - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: a254b661-e86a-45d1-bd5a-f594f29a5a97: [1,False,48T - AMZ - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: a0bccb4e-1c42-4a82-a983-6672c42f5d65: [1,False,48T - AMZ - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: a01a5189-2d88-4d2f-9812-103866c38e4b: [1,False,48T - AMZ - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 9fd08bdd-ecba-4f41-839f-2bebf2b51f19: [1,False,48T - AMZ - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 9fafbb2b-1621-41a1-a901-9832e68a8d5d: [1,False,48T - AMZ - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 9becbf39-f8db-4ba9-ba39-fa3caa9fe773: [1,False,48T - AMZ - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 9b51d176-0c17-4040-b8d3-9ddd4ce72034: [1,False,48T - AMZ - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 9b47e392-b958-4ebb-b0e4-6559ad0b7c1a: [1,False,48T - AMZ - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 9afcb6c3-a764-4e24-a5fc-9d2c9ab2e16d: [1,False,48T - AMZ - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 9add27d7-860a-4e14-8b7c-0fc30a6d8e2b: [1,False,48T - AMZ - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 9a366331-5725-4ee3-af36-49e7dfe10b62: [1,False,48T - AMZ - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 9a2af65b-74c3-4893-a593-5021dc07bdf7: [1,False,48T - AMZ - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 99e18c78-dba2-494b-835a-b7fbebf60352: [1,False,48T - AMZ - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 99cc7c62-bb44-48ec-b863-cc2782ad8054: [1,False,48T - AMZ - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 995fb806-9957-4b72-a0c3-3cd992951977: [1,False,48T - AMZ - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 990e09ba-aec1-4564-ba64-05e9b9be8376: [1,False,48T - AMZ - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 98333a20-6518-4f11-8c30-e872c8ca0762: [1,False,48T - AMZ - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 976ceaab-dc2b-4b83-b617-b97bfa26f7fc: [1,False,48T - AMZ - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 96dac2e3-699d-41b6-9a24-4b7200acff4d: [1,False,48T - AMZ - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 9653ebb2-d122-45e7-9353-c08a9dd2cb4e: [1,False,48T - AMZ - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 951461b2-e12e-4f93-88b1-c4e686dd3f87: [1,False,48T - AMZ - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 950a10c7-c531-402d-b764-d93d2564a459: [1,False,48T - AMZ - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 93e5f924-93f0-4bf4-b1dd-a5238783b7a6: [1,False,48T - AMZ - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 938fbeab-a941-4326-8b8a-d9fc6b87d1dd: [1,False,48T - AMZ - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 935bea59-a220-4f0b-9c47-84308d9155dd: [1,False,48T - AMZ - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 91ddbad7-7f47-409f-9e3d-2eb61750aa0b: [1,False,48T - AMZ - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 917b6ed3-ba7b-4b92-80ee-bf4d3fa43615: [1,False,48T - AMZ - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 90c565cb-622c-4e70-8bf4-defb581db44a: [1,False,48T - AMZ - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 8ffbbffd-873d-4127-8e06-36f8b8c8298f: [1,False,48T - AMZ - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 8f529973-5c98-4fad-a513-b3887bbbb993: [1,False,48T - AMZ - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 8e7b45d3-d724-491e-8b6c-4838c40f8ce7: [1,False,48T - AMZ - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 8d96d5da-320c-4c50-9a3d-4a30b1cb1e9f: [1,False,48T - AMZ - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 8d663e08-a0cb-49f1-a0eb-aabf167c5ea9: [1,False,48T - AMZ - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 8c33c7b6-de11-4fd1-a4a3-8781282c75aa: [1,False,48T - AMZ - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 8bb95a6b-8231-48bc-a9d2-bb1d8782b361: [1,False,48T - AMZ - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 896b4606-a67e-4418-bef9-828334bc453f: [1,False,48T - AMZ - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 8910b9a8-637e-4e23-9c27-81ebf19b335a: [1,False,48T - AMZ - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 88cd07fc-b8c0-4ef5-b709-73a2d8ce5d34: [1,False,48T - AMZ - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 874d2fcd-c64e-44d6-afc9-2a3883c8260b: [1,False,48T - AMZ - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 87149587-f223-424a-9473-a34336a6c864: [1,False,48T - AMZ - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 855b5f72-02d8-470d-bd08-1e3d35ceaeb4: [1,False,48T - AMZ - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 84a3edb4-6a35-4836-9d36-2a313e781870: [1,False,48T - AMZ - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 83135ab8-9bbf-4287-96ed-ebb8af84bd95: [1,False,48T - AMZ - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 81a9a7b5-c6f3-4230-8a86-5896d8f0840b: [1,False,48T - AMZ - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 8055bdf7-93e1-4343-9f96-f2685fccbca1: [1,False,48T - AMZ - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 7edd9937-d21e-4fe6-89e1-f4f21df0a9df: [1,False,48T - AMZ - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 7ea9461e-74d1-4eba-aef4-0ec76808d586: [1,False,48T - AMZ - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 7e1bb487-7031-42dd-bc3c-cd4105b367a8: [1,False,48T - AMZ - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 7df069e1-044f-49cb-8325-d1f7d40028ef: [1,False,48T - AMZ - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 7d0b0159-1898-4c4a-8f02-390037631275: [1,False,48T - AMZ - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 7c847de4-8963-4658-a308-3f75d81f6f37: [1,False,48T - AMZ - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 7c7989c6-705c-4349-93b4-a09782bb4c9b: [1,False,48T - AMZ - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 7c6e567f-2934-41e4-bbce-f40cb9298080: [1,False,48T - AMZ - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 7ba64b58-9d1c-4b04-8faf-31de7289bed9: [1,False,48T - AMZ - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 7ba028f3-04e3-4158-bfa2-68dd3408001b: [1,False,48T - AMZ - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 7a4c6583-d179-4960-ace4-310a1e04e77e: [1,False,48T - AMZ - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 79964516-3618-4054-99be-1349a0e60ee7: [1,False,48T - AMZ - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 79388032-5dfd-4ea8-9d26-4ea3249ee847: [1,False,48T - AMZ - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 792e30dd-f88f-4a93-8a6a-e003807b470e: [1,False,48T - AMZ - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 790b5718-3857-40f9-aa76-b03a5b5222d2: [1,False,48T - AMZ - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 7896d2c2-5a77-4707-89ee-61a096f62ea8: [1,False,48T - AMZ - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 77d2ea5a-1332-46aa-ba6a-1eee1ebcbfb4: [1,False,48T - AMZ - BA]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 8eb9bb08-4afd-457b-ad96-f0e93c1aebf1: [4,False,YODEL LOUNGER XXXL]
result: -1
a: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
b: 765c4fa5-688f-47b2-a41c-cdfef27877df: [1,False,48T - AMZ - BA]
result: 1
a: 77d2ea5a-1332-46aa-ba6a-1eee1ebcbfb4: [1,False,48T - AMZ - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: 77d2ea5a-1332-46aa-ba6a-1eee1ebcbfb4: [1,False,48T - AMZ - BA]
b: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
result: -1
a: 7896d2c2-5a77-4707-89ee-61a096f62ea8: [1,False,48T - AMZ - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: 790b5718-3857-40f9-aa76-b03a5b5222d2: [1,False,48T - AMZ - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: 792e30dd-f88f-4a93-8a6a-e003807b470e: [1,False,48T - AMZ - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: 79388032-5dfd-4ea8-9d26-4ea3249ee847: [1,False,48T - AMZ - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: 79964516-3618-4054-99be-1349a0e60ee7: [1,False,48T - AMZ - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: 7a4c6583-d179-4960-ace4-310a1e04e77e: [1,False,48T - AMZ - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: 7ba028f3-04e3-4158-bfa2-68dd3408001b: [1,False,48T - AMZ - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: 7ba64b58-9d1c-4b04-8faf-31de7289bed9: [1,False,48T - AMZ - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: 7c6e567f-2934-41e4-bbce-f40cb9298080: [1,False,48T - AMZ - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: 7c7989c6-705c-4349-93b4-a09782bb4c9b: [1,False,48T - AMZ - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: 7c847de4-8963-4658-a308-3f75d81f6f37: [1,False,48T - AMZ - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: 7d0b0159-1898-4c4a-8f02-390037631275: [1,False,48T - AMZ - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: 7df069e1-044f-49cb-8325-d1f7d40028ef: [1,False,48T - AMZ - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: 7e1bb487-7031-42dd-bc3c-cd4105b367a8: [1,False,48T - AMZ - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: 7ea9461e-74d1-4eba-aef4-0ec76808d586: [1,False,48T - AMZ - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: 7edd9937-d21e-4fe6-89e1-f4f21df0a9df: [1,False,48T - AMZ - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: 8055bdf7-93e1-4343-9f96-f2685fccbca1: [1,False,48T - AMZ - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: 81a9a7b5-c6f3-4230-8a86-5896d8f0840b: [1,False,48T - AMZ - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: 83135ab8-9bbf-4287-96ed-ebb8af84bd95: [1,False,48T - AMZ - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: 84a3edb4-6a35-4836-9d36-2a313e781870: [1,False,48T - AMZ - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: 855b5f72-02d8-470d-bd08-1e3d35ceaeb4: [1,False,48T - AMZ - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: 87149587-f223-424a-9473-a34336a6c864: [1,False,48T - AMZ - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: 874d2fcd-c64e-44d6-afc9-2a3883c8260b: [1,False,48T - AMZ - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: 88cd07fc-b8c0-4ef5-b709-73a2d8ce5d34: [1,False,48T - AMZ - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: 8910b9a8-637e-4e23-9c27-81ebf19b335a: [1,False,48T - AMZ - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: 896b4606-a67e-4418-bef9-828334bc453f: [1,False,48T - AMZ - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: 8bb95a6b-8231-48bc-a9d2-bb1d8782b361: [1,False,48T - AMZ - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: 8c33c7b6-de11-4fd1-a4a3-8781282c75aa: [1,False,48T - AMZ - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: 8d663e08-a0cb-49f1-a0eb-aabf167c5ea9: [1,False,48T - AMZ - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: 8d96d5da-320c-4c50-9a3d-4a30b1cb1e9f: [1,False,48T - AMZ - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: 8e7b45d3-d724-491e-8b6c-4838c40f8ce7: [1,False,48T - AMZ - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: 8f529973-5c98-4fad-a513-b3887bbbb993: [1,False,48T - AMZ - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: 8ffbbffd-873d-4127-8e06-36f8b8c8298f: [1,False,48T - AMZ - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: 90c565cb-622c-4e70-8bf4-defb581db44a: [1,False,48T - AMZ - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: 917b6ed3-ba7b-4b92-80ee-bf4d3fa43615: [1,False,48T - AMZ - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: 91ddbad7-7f47-409f-9e3d-2eb61750aa0b: [1,False,48T - AMZ - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: 935bea59-a220-4f0b-9c47-84308d9155dd: [1,False,48T - AMZ - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: 938fbeab-a941-4326-8b8a-d9fc6b87d1dd: [1,False,48T - AMZ - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: 93e5f924-93f0-4bf4-b1dd-a5238783b7a6: [1,False,48T - AMZ - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: 950a10c7-c531-402d-b764-d93d2564a459: [1,False,48T - AMZ - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: 951461b2-e12e-4f93-88b1-c4e686dd3f87: [1,False,48T - AMZ - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: 9653ebb2-d122-45e7-9353-c08a9dd2cb4e: [1,False,48T - AMZ - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: 96dac2e3-699d-41b6-9a24-4b7200acff4d: [1,False,48T - AMZ - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: 976ceaab-dc2b-4b83-b617-b97bfa26f7fc: [1,False,48T - AMZ - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: 98333a20-6518-4f11-8c30-e872c8ca0762: [1,False,48T - AMZ - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: 990e09ba-aec1-4564-ba64-05e9b9be8376: [1,False,48T - AMZ - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: 995fb806-9957-4b72-a0c3-3cd992951977: [1,False,48T - AMZ - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: 99cc7c62-bb44-48ec-b863-cc2782ad8054: [1,False,48T - AMZ - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: 99e18c78-dba2-494b-835a-b7fbebf60352: [1,False,48T - AMZ - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: 9a2af65b-74c3-4893-a593-5021dc07bdf7: [1,False,48T - AMZ - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: 9a366331-5725-4ee3-af36-49e7dfe10b62: [1,False,48T - AMZ - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: 9add27d7-860a-4e14-8b7c-0fc30a6d8e2b: [1,False,48T - AMZ - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: 9afcb6c3-a764-4e24-a5fc-9d2c9ab2e16d: [1,False,48T - AMZ - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: 9b47e392-b958-4ebb-b0e4-6559ad0b7c1a: [1,False,48T - AMZ - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: 9b51d176-0c17-4040-b8d3-9ddd4ce72034: [1,False,48T - AMZ - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: 9becbf39-f8db-4ba9-ba39-fa3caa9fe773: [1,False,48T - AMZ - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: 9fafbb2b-1621-41a1-a901-9832e68a8d5d: [1,False,48T - AMZ - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: 9fd08bdd-ecba-4f41-839f-2bebf2b51f19: [1,False,48T - AMZ - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: a01a5189-2d88-4d2f-9812-103866c38e4b: [1,False,48T - AMZ - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: a0bccb4e-1c42-4a82-a983-6672c42f5d65: [1,False,48T - AMZ - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: a254b661-e86a-45d1-bd5a-f594f29a5a97: [1,False,48T - AMZ - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: a2b70450-08b7-4a67-9c84-0c20a9a20a36: [1,False,48T - AMZ - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: a3790182-26d6-4e7e-8013-ad7ce5c554d9: [1,False,48T - AMZ - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: a39c8ed7-e585-4809-8314-a41ec995aaa6: [1,False,48T - AMZ - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: a5214635-1412-4b2e-8904-39477be40369: [1,False,48T - AMZ - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: a533a67b-c440-451e-9661-f26a35736c2d: [1,False,48T - AMZ - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: a53f2782-5ad7-4938-b522-fb5433471473: [1,False,48T - AMZ - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: a8d3175a-ce20-4132-8a4c-cb406de55f95: [1,False,48T - AMZ - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: a9a94122-dbfc-42a7-b39c-666b74df98eb: [1,False,48T - AMZ - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: abca20fd-ccdd-4e07-809f-7f7e35bca140: [1,False,48T - AMZ - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: ac38b4f8-eb29-4121-9bf9-ac5e1290e962: [1,False,48T - AMZ - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: ac9420e4-4645-44c6-96cd-28f5d8361b74: [1,False,48T - AMZ - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: ae02860e-594d-42c4-9529-5f5ef53d0394: [1,False,48T - AMZ - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: ae46f09b-2b5c-4c86-9406-b9a24de5c15d: [1,False,48T - AMZ - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: af486aee-61d8-47e5-b3d5-1f95fe25c4f6: [1,False,48T - AMZ - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: b0de3534-602d-4eda-9453-dabe2aad4e68: [1,False,48T - AMZ - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: b208d7db-8380-4f5d-ba91-ce43100c43e8: [1,False,48T - AMZ - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: b53fcb18-284c-4058-bd3c-f7e2243dbc3e: [1,False,48T - AMZ - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: b636a0a6-d3fc-4753-a344-e9b6c9f7f3f6: [1,False,48T - AMZ - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: b648609a-443e-48a7-aca7-581d8397c94c: [1,False,48T - AMZ - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: b7f65e42-dc5c-43e3-a7e9-bd2888ef142e: [1,False,48T - AMZ - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: b9b3b6fb-9af7-447e-96a5-a0cf7ebedb33: [1,False,48T - AMZ - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: bb9da95d-653e-4ad4-bae6-0bc6bcce09a6: [1,False,48T - AMZ - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: bbc51da0-80c0-487f-a4c1-0aa05cd88501: [1,False,48T - AMZ - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: bbef5e6d-a18f-46d6-94ea-64e402458f8f: [1,False,48T - AMZ - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: bd1225bb-46f0-419a-9b08-b5c5086b3674: [1,False,48T - AMZ - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: bd9a1279-0d9f-4301-a905-2f104780760b: [1,False,48T - AMZ - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: be5cbf8a-1039-43c7-b318-1845070fe624: [1,False,48T - AMZ - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: be883846-f0ac-40de-b367-a3faf321a055: [1,False,48T - AMZ - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: be8b7919-b8f9-4eaf-94c9-22d428862af0: [1,False,48T - AMZ - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: bf763189-d241-4e4d-8af5-a5dcf009a579: [1,False,48T - AMZ - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: bfda0808-4246-4e68-85ae-aff831b76754: [1,False,48T - AMZ - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: c02b24ae-d550-4d76-8c41-0a9f9c9329f0: [1,False,48T - AMZ - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: c0748ec1-98f0-4925-a7dd-1762d00b0668: [1,False,48T - AMZ - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: c17c7529-9786-48ff-ace8-00cd83e02996: [1,False,48T - AMZ - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: c2cd363d-d35f-4d0e-90be-841378cd0856: [1,False,48T - AMZ - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: c3606676-53a0-4067-bb4c-5c0d2d228e8f: [1,False,48T - AMZ - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: c4004d0c-0ce5-486e-8fb9-d23f44a5ce14: [1,False,48T - AMZ - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: c4670360-138a-41bf-bbf7-1f6c65d9558f: [1,False,48T - AMZ - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: c563ac2b-bb22-4bb6-b117-091a0f9cef60: [1,False,48T - AMZ - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: c695df03-3a02-4adf-87de-f91f9130220f: [1,False,48T - AMZ - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: c85ed7d1-c56d-4f5c-89ff-0c4c60ee7ee5: [1,False,48T - AMZ - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: c8bf53fd-aef0-409e-84be-2dae85c62b80: [1,False,48T - AMZ - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: c9860c5d-bd42-4294-8194-198b68055949: [1,False,48T - AMZ - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: cac2498f-5343-4900-ac8b-c4a0e2ebe07d: [1,False,48T - AMZ - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: cbdbbafd-e8ce-4a21-a301-20b53b198261: [1,False,48T - AMZ - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: cc951144-9732-41b3-acd5-12d245aa866d: [1,False,48T - AMZ - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: d05e46c9-8f87-41ae-af30-92ffd17685cf: [1,False,48T - AMZ - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: d13173c0-47c7-49cb-a85d-b577adcfaf4b: [1,False,48T - AMZ - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: d173fdba-b39f-4097-ae4b-508a57b922bd: [1,False,48T - AMZ - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: d1b9e550-5521-4d32-b20d-0564da753a45: [1,False,48T - AMZ - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: d1bb729a-af63-46de-becd-ceec82be1be7: [1,False,48T - AMZ - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: d2870c5b-1dee-4bf1-bdae-9e2b7616a6b3: [1,False,48T - AMZ - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: d324b089-cfe8-496c-813c-3cb5fcc05573: [1,False,48T - AMZ - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: d416b833-8e9f-4f52-b180-a7dfe23d875e: [1,False,48T - AMZ - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: d4265a52-4497-4242-aecc-1562fa7846a2: [1,False,48T - AMZ - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: d5029e68-44ee-49ba-923b-18aa3f2350ff: [1,False,48T - AMZ - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: d60344ed-6018-472a-86e5-81cf82900607: [1,False,48T - AMZ - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: d70a8b30-b5e5-45e4-a248-d619b72a1dbf: [1,False,48T - AMZ - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: d72fedb3-9b0e-45f6-8486-891d9fd2653c: [1,False,48T - AMZ - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: d85c886e-8e57-47a5-8a6c-fd8555fa4d4d: [1,False,48T - AMZ - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: d961321c-2fb1-4e05-a7ee-1a7017c8ad41: [1,False,48T - AMZ - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: d985ddfd-a008-4305-985d-24000175b086: [1,False,48T - AMZ - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: d9eb2bd6-f341-4bfd-9c5b-07cf2f025c8f: [1,False,48T - AMZ - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: da001a73-4f79-4307-8647-ad6c2bd3957d: [1,False,48T - AMZ - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: daa3261c-42a7-491c-8a5c-09ea569c9f1a: [1,False,48T - AMZ - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: dab904bd-e9c9-4d9e-a082-e5826949a125: [1,False,48T - AMZ - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: dc7b2753-5afd-4a29-837d-ae7bcf818bd6: [1,False,48T - AMZ - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: dcf6b836-8903-406a-b339-198a19b5b427: [1,False,48T - AMZ - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: dd727751-39c5-4528-b4af-50450c6d93e7: [1,False,48T - AMZ - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: de68b32b-925b-4577-9dff-876b7ef0805e: [1,False,48T - AMZ - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: e0a2c5b9-efa5-438f-a501-37b48c7fc7f9: [1,False,48T - AMZ - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: e11fd6ab-d954-4a3f-96d2-3dd8c58cd442: [1,False,48T - AMZ - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: e1ba8e07-528b-468c-b7d0-923657993165: [1,False,48T - AMZ - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: e2513f79-7df8-4531-96b6-21b7dd86f859: [1,False,48T - AMZ - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: e3dc270a-adf1-47bc-8499-ed5ddbc9a7ca: [1,False,48T - AMZ - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: e5fcb839-a812-4c7b-97b0-f546b9ac49c9: [1,False,48T - AMZ - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: e690c17c-2d4a-4ae1-aa19-df4379d566bc: [1,False,48T - AMZ - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: e91a3ca4-097f-483a-b351-e6859f71f05c: [1,False,48T - AMZ - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: e942ebb2-bea7-4537-91ba-a0d3868e8d39: [1,False,48T - AMZ - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: e95bb130-69f9-46b6-bf2b-90eb5bd36717: [1,False,48T - AMZ - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: e9dfd1bc-9c70-4c53-b333-51e825ac8678: [1,False,48T - AMZ - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: eb424011-9e21-4b24-9e91-9f36da9b0ed6: [1,False,48T - AMZ - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: eb61bb3e-6b77-4d7f-b82d-93c97ba72f04: [1,False,48T - AMZ - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: edb6a232-ca3d-4931-b080-f192921b7da4: [1,False,48T - AMZ - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: ef695a25-d229-445d-9cbb-8322d056a620: [1,False,48T - AMZ - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: f00c32bd-3b35-45e1-b8bb-b891d37e4a44: [1,False,48T - AMZ - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: f0f82f54-ea83-4c35-8647-47b40ed1dc14: [1,False,48T - AMZ - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: f129c14d-081a-4856-b202-d9b8af7a4b31: [1,False,48T - AMZ - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: f1b1f481-f5b2-4305-abaa-3399ebdb06d8: [1,False,48T - AMZ - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: f1ec2908-3d10-4995-82e9-f1924f67c6eb: [1,False,48T - AMZ - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: f268f4e3-c47b-441a-a17b-ba83b2d393f8: [1,False,48T - AMZ - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: f33e886b-a674-48d1-99fd-51dfbf481c85: [1,False,48T - AMZ - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: f49b78ab-612c-4bb3-8390-91129e0af381: [1,False,48T - AMZ - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: f4bead9a-b6fb-43a8-b225-f13d6909aa40: [1,False,48T - AMZ - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: f4dddd29-a124-4cfe-954f-5c1fdd09d8ee: [1,False,48T - AMZ - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: f5751450-0f0f-4f85-85fd-49a608d3c6f7: [1,False,48T - AMZ - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: f7e00aa1-6f6a-40c8-a138-e9affcb637bf: [1,False,48T - AMZ - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: f88c937a-4455-4413-a484-94bb45858166: [1,False,48T - AMZ - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: f9214b78-be46-410a-9398-4bf880092818: [1,False,48T - AMZ - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: fa5f7375-9c6f-4932-9de0-628ed31723fe: [1,False,48T - AMZ - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: fb8393ea-db54-4fbb-8452-c3cb196440d4: [1,False,48T - AMZ - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: fb99fd40-f0c4-4192-ae87-9ffcf984fe49: [1,False,48T - AMZ - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: fb9a6bed-4f3c-45c2-967f-e0600e6a09ed: [1,False,48T - AMZ - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: fc4992b9-2857-47d3-a241-1a994ad047ca: [1,False,48T - AMZ - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: fd9d80e1-5bbe-43e9-9374-a462c5912f13: [1,False,48T - AMZ - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: fe12eee7-d8b5-49e7-ba53-6e063057d111: [1,False,48T - AMZ - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: fe74a90f-b94f-4af3-b565-c99ccb788d67: [1,False,48T - AMZ - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: fefbaba4-d110-4315-ab59-f10cebb27505: [1,False,48T - AMZ - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: 097153e1-09d2-446d-947c-7a75a686da7e: [1,False,48T - PACKET - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: 0af51d2a-b472-4558-97fc-b7aa371bc1b4: [1,False,48T - PACKET - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: 0e75f49b-8d60-4bf9-90e2-9f54e6df42c5: [1,False,48T - PACKET - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: 10ed79c9-bf2e-4d10-8bf7-13a7240d127c: [1,False,48T - PACKET - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: 1311d166-ae5e-4d2b-b24b-360ab6d56fa0: [1,False,48T - PACKET - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: 1b2932eb-2b0d-4ace-ad05-33bf271eb01d: [1,False,48T - PACKET - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: 1d68c4ba-457f-403b-b397-55525d664853: [1,False,48T - PACKET - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: 1e4be546-e707-4ae0-b583-037eee127b6e: [1,False,48T - PACKET - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: 1f79d75e-e6fa-4108-8b3d-17e8d0752902: [1,False,48T - PACKET - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: 1fd7ad20-b215-4300-ba41-9803c7ec433f: [1,False,48T - PACKET - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: 22d647d3-5afd-4e0d-8a41-9adba9fa2998: [1,False,48T - PACKET - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: 24e3fe30-4fc1-4478-9215-4974f59e10a0: [1,False,48T - PACKET - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: 282e9ee1-24cb-4c59-8ab9-120d88537861: [1,False,48T - PACKET - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: 291eb578-b88e-4fc2-9a13-f1dd1c9242cb: [1,False,48T - PACKET - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: 29726c4e-828f-4c82-9b02-0d395f4a7cd4: [1,False,48T - PACKET - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: 2c2852cc-bc8b-4fc1-ad0a-16d71fb1afc8: [1,False,48T - PACKET - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: 2e7a1715-8f2f-4fdf-a00a-b4552bc04b8d: [1,False,48T - PACKET - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: 2fafed13-237f-42d7-a6ae-df0875549168: [1,False,48T - PACKET - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: 3445a450-bffc-4cf6-930d-4b529769be6d: [1,False,48T - PACKET - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: 35cde69a-2aab-47f9-858a-67f54ffc0270: [1,False,48T - PACKET - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: 37c3eb61-5e87-444c-9e08-bec40d235012: [1,False,48T - PACKET - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: 38cc75a3-ffb2-43ae-8f9f-7e28d3dec82c: [1,False,48T - PACKET - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: 3cb073c2-d468-47d4-b121-884b0a5c8759: [1,False,48T - PACKET - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: 3d53869f-8189-4bba-b2bc-762150aea2a3: [1,False,48T - PACKET - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: 4069355e-e876-4ff9-8c01-acd6d5142fc8: [1,False,48T - PACKET - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: 443ce045-c2b9-4e33-b680-964e8875ac71: [1,False,48T - PACKET - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: 44ca680a-c826-4f35-945c-07e52c2d141a: [1,False,48T - PACKET - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: 457a7145-4523-4a13-81f6-2cc0096eda61: [1,False,48T - PACKET - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: 45c50e41-d97d-47e1-bf79-435008ad3bda: [1,False,48T - PACKET - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: 46477c12-936e-4a46-8b03-14d534f7c403: [1,False,48T - PACKET - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: 47b3dd7e-8637-440f-bed7-56b35e273c71: [1,False,48T - PACKET - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: 4b610cf9-c93f-4b10-bb2f-29c21e962777: [1,False,48T - PACKET - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: 4f56c13f-b224-4a05-8a5a-3a2617fe3b6a: [1,False,48T - PACKET - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: 52faa4c9-039c-43e0-ae66-8b79e1fee354: [1,False,48T - PACKET - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: 5307f9dd-2706-4089-a3b3-64ed361b2193: [1,False,48T - PACKET - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: 5544d2b6-aa2b-4021-8ba3-d7a9f0ba1d2a: [1,False,48T - PACKET - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: 58a80a40-b54f-458d-b318-35566973d7ed: [1,False,48T - PACKET - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: 597c7f97-259e-4ad5-bc35-3a86b5b00cd5: [1,False,48T - PACKET - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: 5bf7dedb-14de-4d42-9b67-8e2301939bdb: [1,False,48T - PACKET - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: 5d29dcae-0617-484b-8230-1b8c0f5800a3: [1,False,48T - PACKET - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: 5e63f102-d4dc-4100-a52b-f75a4057e3c9: [1,False,48T - PACKET - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: 5e8b0b98-056b-4cd2-b744-256e5e785497: [1,False,48T - PACKET - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: 5eeb65ed-b083-49d7-8504-fd1498df3f8a: [1,False,48T - PACKET - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: 62c7b340-7eb4-46c1-98f5-e983d2304db4: [1,False,48T - PACKET - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: 6472f20e-fcea-4320-9e42-2381f9eaad3a: [1,False,48T - PACKET - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: 6608b055-8e25-44dd-869c-db56ecc3151d: [1,False,48T - PACKET - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: 66c76761-7be5-4795-a1ae-35958b76e0b7: [1,False,48T - PACKET - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: 67e2cbe3-0bf0-458e-b649-84f047d16551: [1,False,48T - PACKET - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: 6e432f91-4a45-4a9a-82d8-d12a4b78a762: [1,False,48T - PACKET - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: 6fbb74bb-3e39-4ea9-b7e2-c15691d67d29: [1,False,48T - PACKET - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: 6fe93921-73c6-46d7-a916-a174643a9ea0: [1,False,48T - PACKET - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: 6ffded40-4035-422a-ab67-f01b3c346d00: [1,False,48T - PACKET - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: 71eb32c0-c2c0-4743-b459-7ee725be4f6a: [1,False,48T - PACKET - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: 7980db2e-f844-4ba3-9556-8bf3a70b882b: [1,False,48T - PACKET - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: 7983a807-8273-43f3-ae2c-15e14a705c87: [1,False,48T - PACKET - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: 7b2dba17-943e-4a2c-9505-6f3882c7e950: [1,False,48T - PACKET - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: 7c93b51c-6681-4e06-8a87-e81a55b51ba8: [1,False,48T - PACKET - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: 7fcdac30-bd4b-4c36-89a2-ee497f409a6e: [1,False,48T - PACKET - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: 81771f3d-0c6b-4406-8f43-c7e6c8bbb3c8: [1,False,48T - PACKET - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: 866012c0-dc49-4f0f-9591-b34be96ce89c: [1,False,48T - PACKET - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: 891233d2-d81c-4745-9911-d46801621a06: [1,False,48T - PACKET - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: 8a39bcb1-9475-4135-9af4-04119ec2fad8: [1,False,48T - PACKET - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: 8a74dc7d-2d00-4b73-9f9d-5dfb4cd40881: [1,False,48T - PACKET - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: 8b469361-670f-4494-a8f4-4ede4191ce0d: [1,False,48T - PACKET - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: 8c6d3b20-31f0-4a8f-8a7b-c0d706754b51: [1,False,48T - PACKET - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: 8d3f1fbc-e620-481d-8b84-bb108ddcb16e: [1,False,48T - PACKET - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: 8d7e006f-c98b-4639-a2d1-e547c8953c64: [1,False,48T - PACKET - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: 8f17188a-b13d-470b-8a89-5ad3c2943553: [1,False,48T - PACKET - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: 90f8a86f-fbbe-4735-b40a-b1bc697ae9e8: [1,False,48T - PACKET - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: 94b04203-959b-4bcc-95ea-73c5780d8fd5: [1,False,48T - PACKET - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: 94bbd274-bf94-4f00-8a37-06538f4f4c14: [1,False,48T - PACKET - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: 94d97676-7572-4f84-9f9b-23ec93e46d0a: [1,False,48T - PACKET - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: 988f8023-cb82-4a08-904a-68da954b78ff: [1,False,48T - PACKET - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: 996d1e50-d060-4746-94d4-94f5db542410: [1,False,48T - PACKET - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: 9bc3805c-f9bd-4c63-a6db-7f3c8ad142db: [1,False,48T - PACKET - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: 9e0ef1e9-9d0a-4a85-8559-edbf2242ed94: [1,False,48T - PACKET - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: 9e349215-ebab-4ae4-97b7-a7bbeb083eda: [1,False,48T - PACKET - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: a0fd35ea-fdd1-44f2-8c3e-0bcb22c9bfb8: [1,False,48T - PACKET - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: a3dcafb7-5746-4a96-9d70-6d38f9654873: [1,False,48T - PACKET - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: a6f82dc7-d40c-4c3a-a543-3f99cad57def: [1,False,48T - PACKET - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: aa73b703-fa3e-44ed-9ef1-656aac0fe865: [1,False,48T - PACKET - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: aa9af5f6-2e27-4425-8b06-4a875b4a6e2b: [1,False,48T - PACKET - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: ab4e4aa2-30b2-4d86-a5dd-c57c9d090678: [1,False,48T - PACKET - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: ac4ab5a1-b81b-481f-9005-bc83a515204e: [1,False,48T - PACKET - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: ac668614-81bd-4f04-b135-2e2a2a6aa1b9: [1,False,48T - PACKET - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: b43ea115-a0ad-4472-883e-47faff5d13a3: [1,False,48T - PACKET - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: b6e16545-23cb-4723-acc3-89a8be05deb2: [1,False,48T - PACKET - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: b75217cf-b30a-4df7-9be4-b27cbca70801: [1,False,48T - PACKET - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: b7650cd7-45a0-451a-a650-7bf6acc6ac3c: [1,False,48T - PACKET - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: b77a0b59-77d7-4997-9b3f-f8a46a9cc386: [1,False,48T - PACKET - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: b7f8d52a-a485-4f8e-a4c4-f120d733cfb8: [1,False,48T - PACKET - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: b945daaa-94fb-4657-8c89-21f7b2a7dd29: [1,False,48T - PACKET - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: beddbaaf-6602-42fb-94fd-5a29fa80a081: [1,False,48T - PACKET - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: c0a581a2-9490-468a-b9fb-b7025092d471: [1,False,48T - PACKET - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: c2a1833e-310b-4a36-92c6-e70f0d4f5870: [1,False,48T - PACKET - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: c5af8728-d4c9-4746-85ce-454c16fada70: [1,False,48T - PACKET - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: c69114d1-b29b-4343-8615-eaf275792186: [1,False,48T - PACKET - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: c6d4bb7b-62ec-4980-b3c8-562b9697dc22: [1,False,48T - PACKET - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: c746b42c-6bf2-40a1-a75c-2683c8f6165d: [1,False,48T - PACKET - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: c97cc282-7f93-4377-96d8-f7d10076a614: [1,False,48T - PACKET - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: cb5427b3-874a-4ae8-be1d-c7d35aec545d: [1,False,48T - PACKET - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: ce94327b-bd0d-421c-b03c-f6aa99abd1a6: [1,False,48T - PACKET - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: cf285d25-c7f2-45ac-b2f9-06251eb7b109: [1,False,48T - PACKET - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: d0af9e6a-a42c-46b7-a2e6-bd90a7b4cb15: [1,False,48T - PACKET - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: d5ab5844-ec56-47cf-b4bd-384d582073b6: [1,False,48T - PACKET - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: d736e339-ab2d-4196-a728-6bcc209d0b55: [1,False,48T - PACKET - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: d7b100ec-ebd7-491c-aab1-74f2b2b62176: [1,False,48T - PACKET - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: d8f03863-cfee-4602-9124-ebed405fba5e: [1,False,48T - PACKET - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: dc06a797-3415-4a0f-ba0a-0325dd6dd909: [1,False,48T - PACKET - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: dc3ec536-3ab7-4f6a-982b-0e5224c55fef: [1,False,48T - PACKET - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: df6acf3d-95d0-409d-a232-4bdeb3ae520d: [1,False,48T - PACKET - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: dfe8afb2-bd5b-4ba5-b444-634daa826b06: [1,False,48T - PACKET - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: e051a3b4-2021-4d7c-be26-b7caac64f7b3: [1,False,48T - PACKET - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: e5921012-b3a0-4dae-bba4-20807a3a8474: [1,False,48T - PACKET - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: e8f443da-ef54-49be-b471-f5f727f009f5: [1,False,48T - PACKET - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: e92eac93-bc38-4ab6-8280-0883721631af: [1,False,48T - PACKET - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: ee458f34-0014-4828-aed6-42d8bf786832: [1,False,48T - PACKET - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: ef62b4ac-5427-419c-abd5-173aa16f4e7a: [1,False,48T - PACKET - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: f1d46a43-1190-47cd-9d07-2380aba41ba7: [1,False,48T - PACKET - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: f2fd0820-2f30-448e-9399-48ce2873c39a: [1,False,48T - PACKET - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: f403e954-42d7-4d3e-acf6-344b07fbd457: [1,False,48T - PACKET - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: f5cece49-f03e-453f-be0b-56a179222763: [1,False,48T - PACKET - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: f9862340-5670-40f2-8741-f51e6d0b29c5: [1,False,48T - PACKET - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: fc062024-b0fd-4b20-845e-1794128e41f0: [1,False,48T - PACKET - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: fce581c1-553b-4960-90d3-30cd39ac4e5a: [1,False,48T - PACKET - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: fd5a17a5-7aa3-4e63-a5dc-5640b031a9d0: [1,False,48T - PACKET - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: fe838959-2f44-4dbf-bd53-e85533919ae1: [1,False,48T - PACKET - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: fe977255-e925-442e-8118-c63ada99c91a: [1,False,48T - PACKET - BA]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: 152d3922-7f69-4de1-b9bb-0d1727ce479e: [1,False,AMZ - One Day]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: 166175b3-e6a5-4ad0-ab47-e64acbefd3e5: [1,False,AMZ - One Day]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: 19d8f58b-99bb-43a5-9092-331ed2a0c4f9: [1,False,AMZ - One Day]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: 1c130853-f4e4-4ebc-8185-3e46c2388c6b: [1,False,AMZ - One Day]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: 22fc17a8-d9cc-41c9-9fe1-968f8d396296: [1,False,AMZ - One Day]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: 242fc9ed-f2c5-48da-91c4-0350f68338ef: [1,False,AMZ - One Day]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: 8eb9bb08-4afd-457b-ad96-f0e93c1aebf1: [4,False,YODEL LOUNGER XXXL]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: 1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: c3850c89-d305-4a99-9e7f-1917400795a0: [4,False,XXL UK MAIN]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: 22879b7b-f3f9-45c9-88ad-41c0bfca93df: [4,False,XXL UK MAIN]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: b2a18851-9f95-4266-a669-fd3220738c35: [4,False,UK Mail Next Day - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: f5edc9f3-0747-46b3-a623-92e9c58dd968: [4,False,RM MONTREAL - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: 68abf144-2606-48e0-b84a-32018f937163: [4,False,RM ITALY - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: 7a2eb7db-1dac-4e78-9e65-6b854913dbec: [4,False,RM GERMANY - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: d1aa9fda-f0fa-44f8-a976-e58d75b65010: [4,False,RM FRANCE - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: 83a5d510-b129-4a44-813f-fc42c1f05691: [4,False,RM FRANCE - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: 3dbc8a0a-1fd2-4345-b503-7207343c3932: [4,False,DPD Next Day 12:00 - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: fae33594-a087-4663-a81c-965324f60c82: [4,False,DPD Classic Expresspak - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: 56b949a4-50cc-43dc-8628-ea5e223cecfe: [4,False,DPD Classic - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: fce2463b-96dc-4201-86ac-643fa0928d88: [4,False,48T - PACKET - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: f1774705-d517-4e9a-a500-75dcd3688ac5: [4,False,48T - PACKET - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: cdb566da-4605-4145-8a76-c20931b27665: [4,False,UK Mail Next Day - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: e6585a19-9220-484b-9389-27f6d7418629: [4,False,48T - PACKET - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: c3a23121-879f-464f-836d-a4bf28a77a90: [4,False,48T - PACKET - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: a17bc221-846a-4615-80e1-389d7f2f1976: [4,False,48T - PACKET - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: 71b6dba8-e2cb-4e34-9677-e877e2dff31c: [4,False,48T - PACKET - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: 608bf888-4b13-43a1-9339-293ca14af64b: [4,False,48T - PACKET - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: 5ea587ec-22bd-4eb6-a357-aa4117a30a6f: [4,False,48T - PACKET - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: 38f2068c-e6f0-44de-829c-dd08d320d8d4: [4,False,48T - PACKET - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: 2c1cc50f-25fa-43a9-816b-b0eb74cc2ad4: [4,False,48T - PACKET - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: 1d1677f1-debd-4297-bf33-013960ec6f6a: [4,False,48T - PACKET - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: 0b3594f0-c632-4bf9-9592-bd777ce7605d: [4,False,48T - PACKET - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: 3bc84e93-bbe1-4ba2-99c2-cd70dd385833: [4,False,3H - UK MAIN]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: fcf1f831-dee2-47a3-b2af-ee1e9678c733: [4,False,1H - UK MAIN]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: 81c0362b-3c4e-43ce-a3f6-5ac56c3032d7: [4,False,1H - UK MAIN]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: 7f942cf0-4815-4702-b0ad-b74794c7c100: [4,False,1H - UK MAIN]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: 5aa0e132-0345-4969-898e-6511a1175998: [4,False,1H - UK MAIN]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: 22c88bf4-e0f6-4ea0-8c70-aaaa0fd7cfb9: [4,False,1H - UK MAIN]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: b79958b6-e7ce-43b5-9d7e-b7d4e42fab92: [4,False,1H - BT]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: 7fa22520-c5fd-43f8-be05-c51d2f3edf21: [4,False,1H - BT]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: f563f11f-70e0-4620-bfaf-a57117c6f862: [1,False,YODEL LOUNGER XXXL]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: 16ba9df3-5f17-4e32-bcff-f2128bc74a64: [1,False,YODEL LOUNGER XXXL]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: a8297186-b743-4f44-abd4-99aa351f7b03: [1,False,XXL ISLE]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: e6879e85-beb2-41c0-a6ef-8419a9f93a2e: [1,False,UK Mail Next Day - XXL]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: b9ca8064-2f1e-400a-8b07-06819d36eaa8: [1,False,UK Mail Next Day - XXL]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: 426ae142-d93e-4217-82a5-16bedb0ba6b9: [1,False,UK Mail Next Day - XXL]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: f7b742f7-48be-4c1a-a041-3a09a0491642: [1,False,RM VANCOUVER - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: e0f6b653-4633-4c0a-9282-7386838f3065: [1,False,RM VANCOUVER - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: be4f788f-2720-4c2b-a7c7-e485f9749593: [1,False,RM VANCOUVER - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: ad0745c9-4442-48f3-8e0c-3725323dbb28: [1,False,RM VANCOUVER - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: 85c490a8-0983-42b1-9e9c-c9ff50cc1fb9: [1,False,RM VANCOUVER - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: 731fa41e-864e-42b0-8624-5554f22c1ac4: [1,False,RM VANCOUVER - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: 49518b34-7fc5-452d-8e85-dfc57362ea95: [1,False,RM VANCOUVER - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: 4377f241-5b84-4e63-8fa6-19f0f0153474: [1,False,RM VANCOUVER - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: 149419cf-f132-46e8-92be-784bcd93da43: [1,False,RM VANCOUVER - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: 0f6fd091-ee3d-4773-a993-55735aef8119: [1,False,RM VANCOUVER - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: dfe05612-1a06-4105-82dc-3bf8b750c5b5: [1,False,RM USSFOA - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: 3239d4f9-0be1-4d26-a0c4-5e7dc6b2c076: [1,False,RM USSFOA - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: 2b1a498f-f31b-4775-9d0c-a49c98637865: [1,False,RM USSFOA - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: 0f99c3dc-df5c-4c1d-b710-9f9a9078da2c: [1,False,RM USSFOA - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: c57f2005-a12e-43de-aef4-c950bfa6c624: [1,False,RM USORDA - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: a0414290-a73d-4a26-8123-a6f4496660ab: [1,False,RM USORDA - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: 92fdfff9-7343-4043-95d0-1be8d3e00774: [1,False,RM USORDA - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: 6c52763e-badc-4d7e-9165-cae76d4d9d74: [1,False,RM USORDA - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: 6179bb17-feef-44cc-8ec2-f9e640396847: [1,False,RM USORDA - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: 4ec27f3a-1305-4897-a4cf-e8324944d25a: [1,False,RM USORDA - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: 44c3277b-8c4c-47c9-b987-ed80b1c83380: [1,False,RM USORDA - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: 208d0871-daf7-4169-b860-9bb516a995c0: [1,False,RM USORDA - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: 1965ba6b-0156-4749-a1e3-4ed7a419d81c: [1,False,RM USORDA - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: 0e4edb3b-5acb-4227-9b76-a91f297cc7f2: [1,False,RM USORDA - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: 081860df-3349-4f17-bc87-14baab2ee3d2: [1,False,RM USORDA - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: fbc883e4-e960-4769-85a8-0de06ea26069: [1,False,RM USLAXA - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: f3e11631-dfc4-440d-96dc-f04fb7810127: [1,False,RM USLAXA - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: 9eceff7d-816c-4908-9776-d1bea99a5cdc: [1,False,RM USLAXA - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: 856a3a22-860c-4b4a-8a78-530006460ba4: [1,False,RM USLAXA - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: 767ce763-3c60-42b7-96be-8c0e407f5500: [1,False,RM USLAXA - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: 5cea72ec-d370-4d6a-ab1b-425bbe84d6c9: [1,False,RM USLAXA - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: 49a8751a-41d9-4ccd-aace-29265a8eb7db: [1,False,RM USLAXA - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: 1b814e9c-2706-4aa4-a105-2cdbc5e670fd: [1,False,RM USLAXA - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: 0ff80f3b-a91e-4357-ba86-b339d9a7488c: [1,False,RM USLAXA - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: eaae3178-be80-420b-858d-031a7af23f26: [1,False,RM USJFKA - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: e870ebf5-af6e-4764-a89c-2deab5e9728c: [1,False,RM USJFKA - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: c6efa935-448a-46f5-939e-83672b195102: [1,False,RM USJFKA - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: c6629e65-823e-4048-9877-8bbf1a3e5a77: [1,False,RM USJFKA - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: c548b03d-45ca-4b83-ac8f-205eef8be17c: [1,False,RM USJFKA - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: bfbd81e6-100e-441a-81ea-590a81d3bc3f: [1,False,RM USJFKA - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: a45a07b5-ba2e-4a09-b3d4-5c897c7a6d7a: [1,False,RM USJFKA - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: a2a92676-0f19-4f39-89e7-92dbb4c1de48: [1,False,RM USJFKA - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: 8eb695d7-5773-4c63-aec2-76f874fb4076: [1,False,RM USJFKA - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: 8b7f596e-f203-4a77-bdb8-711f462c117d: [1,False,RM USJFKA - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: 83c0c531-ca32-4cec-802d-2b7ad9fecd3a: [1,False,RM USJFKA - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: 764df177-0d69-47e4-9aa1-c8ba495ab412: [1,False,RM USJFKA - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: 5a3d2010-0816-4613-9b9e-63afd94312b2: [1,False,RM USJFKA - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: 569b232f-fe59-455c-a38b-6e80b9e1cd2b: [1,False,RM USJFKA - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: 4702eb62-a473-4bc2-adf7-effb2619480f: [1,False,RM USJFKA - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: 2e855f49-0d8c-42a3-aa53-05edfc72bb81: [1,False,RM USJFKA - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: 22a236e1-3da8-44f9-b853-f508913641b7: [1,False,RM USJFKA - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: 17ddbe7b-0f83-40d8-916d-9ce0beb4ab0b: [1,False,RM USJFKA - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: f9bb4176-4033-4faf-8681-269e8375d79a: [1,False,RM TORONTO-A - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: f0d94469-7c3f-4780-89f7-17bf97b8af88: [1,False,RM TORONTO-A - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: e1c69b5a-2711-4584-bd9a-555395804082: [1,False,RM TORONTO-A - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: e0b9405c-a4b3-43a5-87d1-f98c878c4ac3: [1,False,RM TORONTO-A - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: d9b1fea0-a484-4b02-b46b-99b7c95ac8a5: [1,False,RM TORONTO-A - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: d614a12b-87a7-46ce-93c7-afd837d8e084: [1,False,RM TORONTO-A - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: bc4ac6d1-bd45-4982-8067-00de502afe55: [1,False,RM TORONTO-A - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: bae0caa1-93eb-4be4-a62c-dfdf4a2ff419: [1,False,RM TORONTO-A - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: a318a335-5fba-4df5-adcf-bb2cb3bbefbc: [1,False,RM TORONTO-A - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: 8c2431c9-d770-4ee0-9ebb-e5dc8683974b: [1,False,RM TORONTO-A - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: 6c10ff57-21d6-4dfb-b397-5a4515284bc5: [1,False,RM TORONTO-A - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: dcd165ec-01f2-4085-9f9b-542ed7725087: [1,False,RM SYDNEY - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: cb5d78e2-bdc6-43ae-b016-7e55ec724c31: [1,False,RM SYDNEY - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: ba02a597-7863-402c-87f5-87cedc62e7d5: [1,False,RM SYDNEY - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: b41fc4a6-837e-4909-ba9d-54399d40ca5e: [1,False,RM SYDNEY - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: b1521865-b4eb-4583-8bfb-fbd5ead6bd42: [1,False,RM SYDNEY - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: af7e76a1-141b-46b6-a8a5-cf04bb40c8ce: [1,False,RM SYDNEY - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: adccd665-00aa-4e72-83ac-aa8b7a291850: [1,False,RM SYDNEY - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: 2ae36886-7696-4c1b-9f81-112d2d1a66c5: [1,False,RM SYDNEY - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: f9376c81-d3c8-424c-aa48-f7ab73831c02: [1,False,RM SPAIN - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: a67d5cf9-fcfb-4f8f-91c0-8194cf1eb0b4: [1,False,RM SPAIN - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: 9c0f7656-4ac4-4fb3-8656-2808b11f340e: [1,False,RM SPAIN - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: 919d9751-bc26-4367-827d-d4964f5344d7: [1,False,RM SPAIN - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: 2c6d8e2f-39be-4023-bef8-06c19c4afe55: [1,False,RM SPAIN - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: a428dcb9-c13a-4bec-9ffd-c9cf379f563b: [1,False,RM REST OF EUROPE - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: 6b9fad4d-b2e2-4b5f-af82-6cdfa187420c: [1,False,RM REST OF EUROPE - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: 536f9023-0696-43a1-ad08-51019e63feb0: [1,False,RM REST OF EUROPE - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: 0b490240-d7e4-42cc-a2a0-2399aafd82e5: [1,False,RM REST OF EUROPE - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: d891bcdb-8e2a-4a06-a971-87e61e32e619: [1,False,RM MONTREAL - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: cfd60973-54ba-459b-a6d2-5a9dd753e2cc: [1,False,RM MONTREAL - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: 750818f1-0a46-4955-a2d6-4861e4c9801f: [1,False,RM MONTREAL - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: 735f16c3-daeb-4167-b39e-a7b341cc030e: [1,False,RM MONTREAL - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: 449d79e6-0018-4ec0-ab0b-e204dbc08819: [1,False,RM MONTREAL - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: 42ffb822-5e16-4760-b7d8-115d253c058b: [1,False,RM MONTREAL - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: 10cf2066-c155-41d6-badb-9a172a521b56: [1,False,RM MONTREAL - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: 718962b1-b0cd-4591-bd82-71e364a87837: [1,False,RM MONTREAL]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: f554beb2-ad59-483d-bb55-75e733bcd8d0: [1,False,RM ITALY - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: ce75038a-426a-4655-8752-c802564f20e2: [1,False,RM ITALY - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: 9e567a9b-16f4-4c57-9c83-786d1366b956: [1,False,RM ITALY - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: 9d8abf88-49de-4066-978c-0f94e778a1af: [1,False,RM ITALY - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: 7da61c05-bfe1-4837-b5d1-e8d750b80af9: [1,False,RM ITALY - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: 6a338913-66d6-409f-b542-8b7427066360: [1,False,RM ITALY - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: 611c46c3-c3ff-49c8-8cc9-6055af127963: [1,False,RM ITALY - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: 59f65080-3ecd-44fa-b096-2f1ab1a2c4a9: [1,False,RM ITALY - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: 51316976-bf3e-480a-ad33-ddf0f060b381: [1,False,RM ITALY - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: 509ee8ea-770a-47d8-a454-188cc82d8748: [1,False,RM ITALY - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: 4056d60b-445a-471b-bce6-2db16ef6d709: [1,False,RM ITALY - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: 32ae31ae-7331-4777-a637-d5d9e158c001: [1,False,RM ITALY - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: 0870a621-0a12-4946-a92f-954beaa132d4: [1,False,RM ITALY - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: 07748c81-5348-4465-b8a6-3f551afa3bf5: [1,False,RM IRELAND - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: ff60d13a-2cc9-41b3-ba9a-a665be1fdbc8: [1,False,RM GERMANY - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: f8ba09e7-5f09-413c-9491-025124542c95: [1,False,RM GERMANY - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: dcfa85bc-b9a9-4382-b090-d40f2d207ecf: [1,False,RM GERMANY - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: d8983815-5402-460a-9ddb-472c49f42e0d: [1,False,RM GERMANY - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: cec806f1-0671-4b0d-b922-c004b92b3c70: [1,False,RM GERMANY - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: ce3a00a0-f9e0-4c7d-b663-02485f9b1089: [1,False,RM GERMANY - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: bf692f58-002b-4fa9-9d07-23149b4ad9f7: [1,False,RM GERMANY - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: bd173af2-34ce-4aab-b93a-e7c7d21d3302: [1,False,RM GERMANY - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: bb68938d-b94a-42fc-aa3b-c1207781a44b: [1,False,RM GERMANY - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: adb5b22f-d513-4a7a-8f15-97a21f63d371: [1,False,RM GERMANY - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: 9cc03f44-0a25-492b-b59d-c4ae9fd7e30c: [1,False,RM GERMANY - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: 993b448f-9ab4-497b-b2d7-1ce338e882bd: [1,False,RM GERMANY - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: 94fe3793-0915-4843-9885-1ca33b7b27a9: [1,False,RM GERMANY - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: 8e9d9bcb-6199-43c0-a682-81f039b1532a: [1,False,RM GERMANY - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: 7f3ee00f-94be-45da-a8ea-5be2ba5ab2cd: [1,False,RM GERMANY - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: 784a058b-4a6e-4ec1-9304-5e6caf0db9b3: [1,False,RM GERMANY - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: 6b5b93a6-a261-4f0d-8e8f-3900f2b70189: [1,False,RM GERMANY - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: 4fb4a868-30c5-4145-a37e-7239202eaa23: [1,False,RM GERMANY - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: 42261f78-27d5-42c1-9768-8a98869c543b: [1,False,RM GERMANY - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: 41cbd59b-42d9-4076-8aa1-bdbd37f54888: [1,False,RM GERMANY - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: 390dc135-0db7-4601-86b2-4cffcf8fe739: [1,False,RM GERMANY - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: 35b8e8c3-b5ba-4b29-98a2-d25ae7cfce61: [1,False,RM GERMANY - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: 25a43ba8-76d8-4b59-9d36-fd8035dd646f: [1,False,RM GERMANY - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: 1a0a105e-323d-493a-a55b-cd496d8afd3a: [1,False,RM GERMANY - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: 16397bf2-1430-4f32-92b6-c012c059de1c: [1,False,RM GERMANY - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: 136d69ea-a372-46c2-bb82-61d300985850: [1,False,RM GERMANY - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: 11c3fa14-b690-4c5b-9dfe-9d23eb753b36: [1,False,RM GERMANY - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: 0b2d8874-b265-45c6-be72-38251928d52b: [1,False,RM GERMANY - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: 02dc99c7-c1e1-414e-aff1-9443cbe02059: [1,False,RM GERMANY - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: f8020843-9945-4e19-ace2-cd72886b8770: [1,False,RM FRANCE - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: ce725884-385c-4c0a-8928-426a910fb610: [1,False,RM FRANCE - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: a75abd4c-23c5-466b-a308-e6ee070eb81b: [1,False,RM FRANCE - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: 91fbc8e5-4727-4e51-911e-1a2b9888e472: [1,False,RM FRANCE - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: 78aa6a12-66a2-4d32-be5a-5af4449b093e: [1,False,RM FRANCE - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: 74a9c265-c5f4-4680-8080-ae4225b0b7f6: [1,False,RM FRANCE - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: 6ac05486-768c-40a5-8766-8f0495060cb1: [1,False,RM FRANCE - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: 567e6620-8f47-4068-abb7-0f9f7d318b8d: [1,False,RM FRANCE - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: 5630edcf-c7b2-4f3c-9361-db28f5bd7337: [1,False,RM FRANCE - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: 55359202-2db5-429e-9ebb-8b04681ff839: [1,False,RM FRANCE - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: 42c74b35-40c6-4be6-923f-76023e897086: [1,False,RM FRANCE - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: 3db77550-932c-4aab-8780-1986b631a102: [1,False,RM FRANCE - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: 30738c2b-2e4d-4182-b3db-3ad0c7316eb6: [1,False,RM FRANCE - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: 268e727f-0f0f-4b10-8d3e-b3e79c7dde8a: [1,False,RM FRANCE - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: 0fea7c72-731a-448a-b55f-297fef4e2eaa: [1,False,RM FRANCE - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: 000b1b60-647a-4a79-ac46-6c6b1e8bd900: [1,False,RM FRANCE - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: df916b12-8195-4541-9bc0-fa5d37fcbb7d: [1,False,DPD Two Day - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: 9ee344bd-0e78-4776-9f5d-bcbbb85ac6c0: [1,False,DPD Next Day - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: 9a2b2898-b90e-4736-ac33-c3b0c4700e02: [1,False,DPD Next Day - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: 067b7bcf-d78d-4860-b658-75243a434acb: [1,False,DPD Next Day - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: ff84197b-e536-4117-883a-bcf87e073a7c: [1,False,DPD Classic Expresspak - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: cdb797c7-867c-411a-9b67-f5e15109d102: [1,False,DPD Classic Expresspak - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: c46952ca-19fe-4e4d-b228-fcb79aeab4d0: [1,False,DPD Classic Expresspak - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: b8f3cc71-4819-4519-b4cd-03bd1f54d3ac: [1,False,DPD Classic Expresspak - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: 87b7d72f-1def-49fc-b443-9d5ea5022fec: [1,False,DPD Classic Expresspak - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: 860b4936-031c-47e3-a446-637962127e41: [1,False,DPD Classic Expresspak - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: 7fb4b931-56ae-47ff-908f-83c973163abb: [1,False,DPD Classic Expresspak - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: 7dedd79a-f02c-47a4-8033-63b483221fe5: [1,False,DPD Classic Expresspak - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: 70dac18d-9152-4af7-a45f-3cc00d0ba81b: [1,False,DPD Classic Expresspak - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: 652fd3c3-a2b5-4588-bcd2-e1b9e78cb8b3: [1,False,DPD Classic Expresspak - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: 625a3390-cab4-4426-ba68-a90946369a78: [1,False,DPD Classic Expresspak - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: 565d7b9f-f164-472f-b0b9-4d8975a9f9a6: [1,False,DPD Classic Expresspak - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: 56198c73-5de3-4110-8a23-555347e367ad: [1,False,DPD Classic Expresspak - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: 3de97972-b9da-4138-8c57-d7004d2efdde: [1,False,DPD Classic Expresspak - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: 268710af-0a4d-4be1-b39e-de9019665560: [1,False,DPD Classic Expresspak - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: 1df40278-6fe6-45e1-9684-d0438a695b93: [1,False,DPD Classic Expresspak - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: 046aaef3-4ad2-4898-90e6-e0c8eda7885c: [1,False,DPD Classic Expresspak - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: ef00e9de-a80e-4154-a205-3e19cf3a474c: [1,False,DPD Classic - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: eefba6dd-abd1-403b-abe4-5a54c7f62150: [1,False,DPD Classic - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: d96b6524-bc92-4c0a-a883-be31f899963e: [1,False,DPD Classic - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: d52c27b7-c077-49b2-945e-5b985fcd5a0e: [1,False,DPD Classic - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: d3644de3-1c37-44f9-99c3-881f299ec74d: [1,False,DPD Classic - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: d26ef10d-558f-427d-a2c3-ff29ac2f6338: [1,False,DPD Classic - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: d138183a-5b41-4053-9283-17779217678c: [1,False,DPD Classic - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: d1047b2b-9f0d-45fa-8e86-1f175cfa43c6: [1,False,DPD Classic - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: d0520844-babb-46de-aed1-8da82917ecd2: [1,False,DPD Classic - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: cbd3b004-7256-458d-a93d-acf01495cedc: [1,False,DPD Classic - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: c4f85ab8-8893-4507-8b43-1a55e2aec07e: [1,False,DPD Classic - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: c38c9491-d2e9-4cc0-9ebb-71e75e3d9e29: [1,False,DPD Classic - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: bbfb3134-cbc6-414c-b411-14f03b501b9a: [1,False,DPD Classic - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: b90921fb-55df-448b-82ca-5c704f38c989: [1,False,DPD Classic - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: b868edea-91fd-4c81-a257-7dd7a050425a: [1,False,DPD Classic - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: b5a762af-6dcc-4681-af59-4bdd360ff27f: [1,False,DPD Classic - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: b1d8903e-0e58-4d15-84fc-f5d893dc87dd: [1,False,DPD Classic - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: adab7fbf-babd-430b-8651-3b2a1074145b: [1,False,DPD Classic - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: 9bdc0514-845f-4b6a-af83-80e1773bc94a: [1,False,DPD Classic - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: 9a48b4b8-e600-44c4-b8a4-53fa93aaaf63: [1,False,DPD Classic - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: 991a180c-85e4-4d77-be13-9439233be9c0: [1,False,DPD Classic - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: 990d6606-69b5-4247-b9f9-a7f84cbcb057: [1,False,DPD Classic - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: 91e5a70b-1926-4c8a-be48-9d736f574ce8: [1,False,DPD Classic - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: 90abf2f5-2927-4b9b-a50e-47e76150fc4f: [1,False,DPD Classic - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: 8e43f589-d838-4de6-8473-3d78a9ecb7cd: [1,False,DPD Classic - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: 8cf2475e-4fb5-4563-b9cf-d79e9cb06a2a: [1,False,DPD Classic - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: 8496b87b-be69-4475-8a5c-4b80cb6d334c: [1,False,DPD Classic - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: 82aba3a7-068d-4eff-898f-59fc3783669b: [1,False,DPD Classic - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: 82a6ff6c-ccc7-456e-9e70-867283eabc79: [1,False,DPD Classic - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: 7dbe183a-acef-4383-8caf-71449e6cf769: [1,False,DPD Classic - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: 7c973fc3-54c0-4434-8562-98b63b0c6c1c: [1,False,DPD Classic - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: 7a4c64a3-1522-4044-b8d7-88076a8971c7: [1,False,DPD Classic - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: 756ff103-1ac1-434b-a78b-8303a9d4a6eb: [1,False,DPD Classic - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: 71efc5f3-558d-4e50-8f1a-0ce18ee07bef: [1,False,DPD Classic - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: 700b7ac3-d190-4139-9076-4da9e4068004: [1,False,DPD Classic - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: 6dc72da3-84f5-45eb-9db5-52c9e10ac5c0: [1,False,DPD Classic - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: 685200a1-a695-4a81-9115-e5a8660ce8aa: [1,False,DPD Classic - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: 5c3d4c5c-9eb1-4bc2-8aed-c2d0fb20afb0: [1,False,DPD Classic - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: 54adbd00-b1ee-4ee9-9fc9-4262dcfde829: [1,False,DPD Classic - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: 4bfe3f0f-8503-471e-a729-7a2bbd2597e4: [1,False,DPD Classic - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: 424a9953-b7b9-446d-9e5b-10a19ff41978: [1,False,DPD Classic - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: 40b8dcd4-9a45-4dd4-abf6-0ffbcfa439b3: [1,False,DPD Classic - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: 4083624b-2a07-45f4-8007-ee172dc5fa92: [1,False,DPD Classic - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: 3ed3c831-94f3-4344-8e1c-be0cbe21b4eb: [1,False,DPD Classic - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: 1da99bc4-d85b-4387-8dd6-dd574e259052: [1,False,DPD Classic - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: 1c162d64-e9c8-474f-bf96-3caf2469feeb: [1,False,DPD Classic - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: 13a506ab-bf13-4b0d-8518-940d275033f3: [1,False,DPD Classic - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: 0f6e0e74-1189-4409-873e-d2e0cbae8c6f: [1,False,DPD Classic - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: 05aba421-033d-41c7-bfe1-bbc650e913d5: [1,False,DPD Classic - BA]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: f49bf874-0db1-41e4-9450-6c2c02f4ce96: [1,False,AMZ - One Day]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: f3c67464-daef-4c13-8d85-2943625a8ead: [1,False,AMZ - One Day]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: dfcb130a-eec7-4793-ba27-9d586abb9e89: [1,False,AMZ - One Day]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: d8ecae93-6070-400c-8de6-6430a6179902: [1,False,AMZ - One Day]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: d11ba35f-6564-4a29-8294-efe9d0d36528: [1,False,AMZ - One Day]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: cdf23ba3-233d-4573-a538-04eefa8a25cf: [1,False,AMZ - One Day]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: cc03922b-d324-4aae-a9ef-216adf8760bc: [1,False,AMZ - One Day]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: cbccf400-46d7-40ca-8a77-35258e656bc4: [1,False,AMZ - One Day]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: cb84bb96-8c23-46f8-973d-bd1058f84300: [1,False,AMZ - One Day]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: c97df469-be62-4141-8cf4-a9c9ba6d3151: [1,False,AMZ - One Day]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: c77df67d-574d-47ca-83fa-36284ca074c3: [1,False,AMZ - One Day]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: c227b3fa-0071-4a5a-9ae3-78f917e57dce: [1,False,AMZ - One Day]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: c0326fc7-ef54-44d1-ad61-c81bd7b9d345: [1,False,AMZ - One Day]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: bd7b20de-3eb3-4ced-8b1a-e42c2d8bff71: [1,False,AMZ - One Day]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: bc27142e-afc4-46d1-92a2-930125826097: [1,False,AMZ - One Day]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: b343c596-a195-46d6-9ad9-07616c27a706: [1,False,AMZ - One Day]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: ae1fcc7a-b8f2-4322-af09-bdc60ac42a9e: [1,False,AMZ - One Day]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: a26d7096-9f45-4684-8e1c-98b31e5b7880: [1,False,AMZ - One Day]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: 9711c60e-b722-4abc-8633-73eb16746c99: [1,False,AMZ - One Day]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: 91ec16ee-7806-4dda-af43-651111728752: [1,False,AMZ - One Day]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: 8f16e1ca-5041-46c3-9e46-40524aaf9bef: [1,False,AMZ - One Day]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: 8d643d02-ab4f-4d9b-8fb0-6f820f6d25ff: [1,False,AMZ - One Day]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: 867c1e52-8c72-460d-8b18-a52ec07916b1: [1,False,AMZ - One Day]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: 82cb9f2b-8042-41b8-8bcc-d7dfa56aedc2: [1,False,AMZ - One Day]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: 7d6f6404-4ab8-414a-98de-7cc50428fedd: [1,False,AMZ - One Day]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: 7d541c72-bc87-4617-b191-e8687dd95d02: [1,False,AMZ - One Day]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: 7885c2e2-de1e-4794-9c9e-2dfa6d3dfd10: [1,False,AMZ - One Day]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: 774070d2-248b-44ad-97fa-fd8c6607562b: [1,False,AMZ - One Day]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: 75a2f269-2477-40d0-a984-d5bf0833e8bb: [1,False,AMZ - One Day]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: 71ccbb36-cd8b-46a8-aa72-92ec3fb741fc: [1,False,AMZ - One Day]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: 7160b093-cb80-4454-9026-82682b8c0430: [1,False,AMZ - One Day]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: 6be21c23-9bae-4c93-ab45-c78fec532f8f: [1,False,AMZ - One Day]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: 69b5b444-1a4c-4e7f-82a7-55ef82dfa2ae: [1,False,AMZ - One Day]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: 69b18b34-00f7-415d-9ecc-093a2c270545: [1,False,AMZ - One Day]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: 640008ad-baac-4ab5-be45-be4fac34f6db: [1,False,AMZ - One Day]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: 63ef01f1-e82a-4c7e-945c-a0f7c0f935f3: [1,False,AMZ - One Day]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: 5c31abc2-941f-4645-9046-4511237a1a6b: [1,False,AMZ - One Day]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: 5b59d53d-f519-4519-833e-c102da0811e8: [1,False,AMZ - One Day]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: 5488101b-4b3d-4874-9793-e59cd3e47c61: [1,False,AMZ - One Day]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: 4f81a35e-f23c-4163-88ba-4ea71bb3d10b: [1,False,AMZ - One Day]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: 4dd4d120-0e76-47d5-92d0-517c7c388ec2: [1,False,AMZ - One Day]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: 4d7055f9-c2f8-4ab1-924c-6a22ebc4802e: [1,False,AMZ - One Day]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: 48b0f4df-cbf3-427d-8ee7-0beb8ebe2c0d: [1,False,AMZ - One Day]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: 3de3d86f-8c4c-4f45-90c1-1ab076e79940: [1,False,AMZ - One Day]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: 38d78fa7-7e60-48e3-aafc-2f5d7455ebc5: [1,False,AMZ - One Day]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: 3056712b-ad4b-4658-a088-44d2ebdb0b2a: [1,False,AMZ - One Day]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: 2e2b9a50-e2d9-4286-a809-c4ca41c8304e: [1,False,AMZ - One Day]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: 8eb9bb08-4afd-457b-ad96-f0e93c1aebf1: [4,False,YODEL LOUNGER XXXL]
result: -1
a: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
b: 242fc9ed-f2c5-48da-91c4-0350f68338ef: [1,False,AMZ - One Day]
result: 1
a: 2e2b9a50-e2d9-4286-a809-c4ca41c8304e: [1,False,AMZ - One Day]
b: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
result: -1
a: 2e2b9a50-e2d9-4286-a809-c4ca41c8304e: [1,False,AMZ - One Day]
b: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
result: -1
a: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
b: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
result: -1
a: 3056712b-ad4b-4658-a088-44d2ebdb0b2a: [1,False,AMZ - One Day]
b: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
result: -1
a: 38d78fa7-7e60-48e3-aafc-2f5d7455ebc5: [1,False,AMZ - One Day]
b: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
result: -1
a: 3de3d86f-8c4c-4f45-90c1-1ab076e79940: [1,False,AMZ - One Day]
b: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
result: -1
a: 48b0f4df-cbf3-427d-8ee7-0beb8ebe2c0d: [1,False,AMZ - One Day]
b: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
result: -1
a: 4d7055f9-c2f8-4ab1-924c-6a22ebc4802e: [1,False,AMZ - One Day]
b: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
result: -1
a: 4dd4d120-0e76-47d5-92d0-517c7c388ec2: [1,False,AMZ - One Day]
b: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
result: -1
a: 4f81a35e-f23c-4163-88ba-4ea71bb3d10b: [1,False,AMZ - One Day]
b: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
result: -1
a: 5488101b-4b3d-4874-9793-e59cd3e47c61: [1,False,AMZ - One Day]
b: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
result: -1
a: 5b59d53d-f519-4519-833e-c102da0811e8: [1,False,AMZ - One Day]
b: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
result: -1
a: 5c31abc2-941f-4645-9046-4511237a1a6b: [1,False,AMZ - One Day]
b: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
result: -1
a: 63ef01f1-e82a-4c7e-945c-a0f7c0f935f3: [1,False,AMZ - One Day]
b: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
result: -1
a: 640008ad-baac-4ab5-be45-be4fac34f6db: [1,False,AMZ - One Day]
b: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
result: -1
a: 69b18b34-00f7-415d-9ecc-093a2c270545: [1,False,AMZ - One Day]
b: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
result: -1
a: 69b5b444-1a4c-4e7f-82a7-55ef82dfa2ae: [1,False,AMZ - One Day]
b: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
result: -1
a: 6be21c23-9bae-4c93-ab45-c78fec532f8f: [1,False,AMZ - One Day]
b: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
result: -1
a: 7160b093-cb80-4454-9026-82682b8c0430: [1,False,AMZ - One Day]
b: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
result: -1
a: 71ccbb36-cd8b-46a8-aa72-92ec3fb741fc: [1,False,AMZ - One Day]
b: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
result: -1
a: 75a2f269-2477-40d0-a984-d5bf0833e8bb: [1,False,AMZ - One Day]
b: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
result: -1
a: 774070d2-248b-44ad-97fa-fd8c6607562b: [1,False,AMZ - One Day]
b: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
result: -1
a: 7885c2e2-de1e-4794-9c9e-2dfa6d3dfd10: [1,False,AMZ - One Day]
b: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
result: -1
a: 7d541c72-bc87-4617-b191-e8687dd95d02: [1,False,AMZ - One Day]
b: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
result: -1
a: 7d6f6404-4ab8-414a-98de-7cc50428fedd: [1,False,AMZ - One Day]
b: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
result: -1
a: 82cb9f2b-8042-41b8-8bcc-d7dfa56aedc2: [1,False,AMZ - One Day]
b: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
result: -1
a: 867c1e52-8c72-460d-8b18-a52ec07916b1: [1,False,AMZ - One Day]
b: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
result: -1
a: 8d643d02-ab4f-4d9b-8fb0-6f820f6d25ff: [1,False,AMZ - One Day]
b: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
result: -1
a: 8f16e1ca-5041-46c3-9e46-40524aaf9bef: [1,False,AMZ - One Day]
b: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
result: -1
a: 91ec16ee-7806-4dda-af43-651111728752: [1,False,AMZ - One Day]
b: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
result: -1
a: 9711c60e-b722-4abc-8633-73eb16746c99: [1,False,AMZ - One Day]
b: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
result: -1
a: a26d7096-9f45-4684-8e1c-98b31e5b7880: [1,False,AMZ - One Day]
b: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
result: -1
a: ae1fcc7a-b8f2-4322-af09-bdc60ac42a9e: [1,False,AMZ - One Day]
b: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
result: -1
a: b343c596-a195-46d6-9ad9-07616c27a706: [1,False,AMZ - One Day]
b: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
result: -1
a: bc27142e-afc4-46d1-92a2-930125826097: [1,False,AMZ - One Day]
b: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
result: -1
a: bd7b20de-3eb3-4ced-8b1a-e42c2d8bff71: [1,False,AMZ - One Day]
b: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
result: -1
a: c0326fc7-ef54-44d1-ad61-c81bd7b9d345: [1,False,AMZ - One Day]
b: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
result: -1
a: c227b3fa-0071-4a5a-9ae3-78f917e57dce: [1,False,AMZ - One Day]
b: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
result: -1
a: c77df67d-574d-47ca-83fa-36284ca074c3: [1,False,AMZ - One Day]
b: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
result: -1
a: c97df469-be62-4141-8cf4-a9c9ba6d3151: [1,False,AMZ - One Day]
b: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
result: -1
a: cb84bb96-8c23-46f8-973d-bd1058f84300: [1,False,AMZ - One Day]
b: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
result: -1
a: cbccf400-46d7-40ca-8a77-35258e656bc4: [1,False,AMZ - One Day]
b: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
result: -1
a: cc03922b-d324-4aae-a9ef-216adf8760bc: [1,False,AMZ - One Day]
b: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
result: -1
a: cdf23ba3-233d-4573-a538-04eefa8a25cf: [1,False,AMZ - One Day]
b: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
result: -1
a: d11ba35f-6564-4a29-8294-efe9d0d36528: [1,False,AMZ - One Day]
b: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
result: -1
a: d8ecae93-6070-400c-8de6-6430a6179902: [1,False,AMZ - One Day]
b: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
result: -1
a: dfcb130a-eec7-4793-ba27-9d586abb9e89: [1,False,AMZ - One Day]
b: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
result: -1
a: f3c67464-daef-4c13-8d85-2943625a8ead: [1,False,AMZ - One Day]
b: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
result: -1
a: f49bf874-0db1-41e4-9450-6c2c02f4ce96: [1,False,AMZ - One Day]
b: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
result: -1
a: 05aba421-033d-41c7-bfe1-bbc650e913d5: [1,False,DPD Classic - BA]
b: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
result: -1
a: 0f6e0e74-1189-4409-873e-d2e0cbae8c6f: [1,False,DPD Classic - BA]
b: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
result: -1
a: 13a506ab-bf13-4b0d-8518-940d275033f3: [1,False,DPD Classic - BA]
b: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
result: -1
a: 1c162d64-e9c8-474f-bf96-3caf2469feeb: [1,False,DPD Classic - BA]
b: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
result: -1
a: 1da99bc4-d85b-4387-8dd6-dd574e259052: [1,False,DPD Classic - BA]
b: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
result: -1
a: 3ed3c831-94f3-4344-8e1c-be0cbe21b4eb: [1,False,DPD Classic - BA]
b: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
result: -1
a: 4083624b-2a07-45f4-8007-ee172dc5fa92: [1,False,DPD Classic - BA]
b: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
result: -1
a: 40b8dcd4-9a45-4dd4-abf6-0ffbcfa439b3: [1,False,DPD Classic - BA]
b: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
result: -1
a: 424a9953-b7b9-446d-9e5b-10a19ff41978: [1,False,DPD Classic - BA]
b: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
result: -1
a: 4bfe3f0f-8503-471e-a729-7a2bbd2597e4: [1,False,DPD Classic - BA]
b: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
result: -1
a: 54adbd00-b1ee-4ee9-9fc9-4262dcfde829: [1,False,DPD Classic - BA]
b: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
result: -1
a: 5c3d4c5c-9eb1-4bc2-8aed-c2d0fb20afb0: [1,False,DPD Classic - BA]
b: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
result: -1
a: 685200a1-a695-4a81-9115-e5a8660ce8aa: [1,False,DPD Classic - BA]
b: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
result: -1
a: 6dc72da3-84f5-45eb-9db5-52c9e10ac5c0: [1,False,DPD Classic - BA]
b: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
result: -1
a: 700b7ac3-d190-4139-9076-4da9e4068004: [1,False,DPD Classic - BA]
b: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
result: -1
a: 71efc5f3-558d-4e50-8f1a-0ce18ee07bef: [1,False,DPD Classic - BA]
b: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
result: -1
a: 756ff103-1ac1-434b-a78b-8303a9d4a6eb: [1,False,DPD Classic - BA]
b: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
result: -1
a: 7a4c64a3-1522-4044-b8d7-88076a8971c7: [1,False,DPD Classic - BA]
b: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
result: -1
a: 7c973fc3-54c0-4434-8562-98b63b0c6c1c: [1,False,DPD Classic - BA]
b: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
result: -1
a: 7dbe183a-acef-4383-8caf-71449e6cf769: [1,False,DPD Classic - BA]
b: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
result: -1
a: 82a6ff6c-ccc7-456e-9e70-867283eabc79: [1,False,DPD Classic - BA]
b: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
result: -1
a: 82aba3a7-068d-4eff-898f-59fc3783669b: [1,False,DPD Classic - BA]
b: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
result: -1
a: 8496b87b-be69-4475-8a5c-4b80cb6d334c: [1,False,DPD Classic - BA]
b: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
result: -1
a: 8cf2475e-4fb5-4563-b9cf-d79e9cb06a2a: [1,False,DPD Classic - BA]
b: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
result: -1
a: 8e43f589-d838-4de6-8473-3d78a9ecb7cd: [1,False,DPD Classic - BA]
b: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
result: -1
a: 90abf2f5-2927-4b9b-a50e-47e76150fc4f: [1,False,DPD Classic - BA]
b: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
result: -1
a: 91e5a70b-1926-4c8a-be48-9d736f574ce8: [1,False,DPD Classic - BA]
b: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
result: -1
a: 990d6606-69b5-4247-b9f9-a7f84cbcb057: [1,False,DPD Classic - BA]
b: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
result: -1
a: 991a180c-85e4-4d77-be13-9439233be9c0: [1,False,DPD Classic - BA]
b: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
result: -1
a: 9a48b4b8-e600-44c4-b8a4-53fa93aaaf63: [1,False,DPD Classic - BA]
b: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
result: -1
a: 9bdc0514-845f-4b6a-af83-80e1773bc94a: [1,False,DPD Classic - BA]
b: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
result: -1
a: adab7fbf-babd-430b-8651-3b2a1074145b: [1,False,DPD Classic - BA]
b: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
result: -1
a: b1d8903e-0e58-4d15-84fc-f5d893dc87dd: [1,False,DPD Classic - BA]
b: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
result: -1
a: b5a762af-6dcc-4681-af59-4bdd360ff27f: [1,False,DPD Classic - BA]
b: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
result: -1
a: b868edea-91fd-4c81-a257-7dd7a050425a: [1,False,DPD Classic - BA]
b: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
result: -1
a: b90921fb-55df-448b-82ca-5c704f38c989: [1,False,DPD Classic - BA]
b: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
result: -1
a: bbfb3134-cbc6-414c-b411-14f03b501b9a: [1,False,DPD Classic - BA]
b: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
result: -1
a: c38c9491-d2e9-4cc0-9ebb-71e75e3d9e29: [1,False,DPD Classic - BA]
b: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
result: -1
a: c4f85ab8-8893-4507-8b43-1a55e2aec07e: [1,False,DPD Classic - BA]
b: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
result: -1
a: cbd3b004-7256-458d-a93d-acf01495cedc: [1,False,DPD Classic - BA]
b: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
result: -1
a: d0520844-babb-46de-aed1-8da82917ecd2: [1,False,DPD Classic - BA]
b: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
result: -1
a: d1047b2b-9f0d-45fa-8e86-1f175cfa43c6: [1,False,DPD Classic - BA]
b: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
result: -1
a: d138183a-5b41-4053-9283-17779217678c: [1,False,DPD Classic - BA]
b: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
result: -1
a: d26ef10d-558f-427d-a2c3-ff29ac2f6338: [1,False,DPD Classic - BA]
b: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
result: -1
a: d3644de3-1c37-44f9-99c3-881f299ec74d: [1,False,DPD Classic - BA]
b: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
result: -1
a: d52c27b7-c077-49b2-945e-5b985fcd5a0e: [1,False,DPD Classic - BA]
b: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
result: -1
a: d96b6524-bc92-4c0a-a883-be31f899963e: [1,False,DPD Classic - BA]
b: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
result: -1
a: eefba6dd-abd1-403b-abe4-5a54c7f62150: [1,False,DPD Classic - BA]
b: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
result: -1
a: ef00e9de-a80e-4154-a205-3e19cf3a474c: [1,False,DPD Classic - BA]
b: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
result: -1
a: 046aaef3-4ad2-4898-90e6-e0c8eda7885c: [1,False,DPD Classic Expresspak - BA]
b: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
result: -1
a: 1df40278-6fe6-45e1-9684-d0438a695b93: [1,False,DPD Classic Expresspak - BA]
b: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
result: -1
a: 268710af-0a4d-4be1-b39e-de9019665560: [1,False,DPD Classic Expresspak - BA]
b: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
result: -1
a: 3de97972-b9da-4138-8c57-d7004d2efdde: [1,False,DPD Classic Expresspak - BA]
b: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
result: -1
a: 56198c73-5de3-4110-8a23-555347e367ad: [1,False,DPD Classic Expresspak - BA]
b: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
result: -1
a: 565d7b9f-f164-472f-b0b9-4d8975a9f9a6: [1,False,DPD Classic Expresspak - BA]
b: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
result: -1
a: 625a3390-cab4-4426-ba68-a90946369a78: [1,False,DPD Classic Expresspak - BA]
b: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
result: -1
a: 652fd3c3-a2b5-4588-bcd2-e1b9e78cb8b3: [1,False,DPD Classic Expresspak - BA]
b: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
result: -1
a: 70dac18d-9152-4af7-a45f-3cc00d0ba81b: [1,False,DPD Classic Expresspak - BA]
b: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
result: -1
a: 7dedd79a-f02c-47a4-8033-63b483221fe5: [1,False,DPD Classic Expresspak - BA]
b: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
result: -1
a: 7fb4b931-56ae-47ff-908f-83c973163abb: [1,False,DPD Classic Expresspak - BA]
b: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
result: -1
a: 860b4936-031c-47e3-a446-637962127e41: [1,False,DPD Classic Expresspak - BA]
b: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
result: -1
a: 87b7d72f-1def-49fc-b443-9d5ea5022fec: [1,False,DPD Classic Expresspak - BA]
b: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
result: -1
a: b8f3cc71-4819-4519-b4cd-03bd1f54d3ac: [1,False,DPD Classic Expresspak - BA]
b: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
result: -1
a: c46952ca-19fe-4e4d-b228-fcb79aeab4d0: [1,False,DPD Classic Expresspak - BA]
b: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
result: -1
a: cdb797c7-867c-411a-9b67-f5e15109d102: [1,False,DPD Classic Expresspak - BA]
b: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
result: -1
a: ff84197b-e536-4117-883a-bcf87e073a7c: [1,False,DPD Classic Expresspak - BA]
b: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
result: -1
a: 067b7bcf-d78d-4860-b658-75243a434acb: [1,False,DPD Next Day - BA]
b: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
result: -1
a: 9a2b2898-b90e-4736-ac33-c3b0c4700e02: [1,False,DPD Next Day - BA]
b: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
result: -1
a: 9ee344bd-0e78-4776-9f5d-bcbbb85ac6c0: [1,False,DPD Next Day - BA]
b: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
result: -1
a: df916b12-8195-4541-9bc0-fa5d37fcbb7d: [1,False,DPD Two Day - BA]
b: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
result: -1
a: 000b1b60-647a-4a79-ac46-6c6b1e8bd900: [1,False,RM FRANCE - BA]
b: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
result: -1
a: 0fea7c72-731a-448a-b55f-297fef4e2eaa: [1,False,RM FRANCE - BA]
b: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
result: -1
a: 268e727f-0f0f-4b10-8d3e-b3e79c7dde8a: [1,False,RM FRANCE - BA]
b: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
result: -1
a: 30738c2b-2e4d-4182-b3db-3ad0c7316eb6: [1,False,RM FRANCE - BA]
b: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
result: -1
a: 3db77550-932c-4aab-8780-1986b631a102: [1,False,RM FRANCE - BA]
b: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
result: -1
a: 42c74b35-40c6-4be6-923f-76023e897086: [1,False,RM FRANCE - BA]
b: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
result: -1
a: 55359202-2db5-429e-9ebb-8b04681ff839: [1,False,RM FRANCE - BA]
b: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
result: -1
a: 5630edcf-c7b2-4f3c-9361-db28f5bd7337: [1,False,RM FRANCE - BA]
b: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
result: -1
a: 567e6620-8f47-4068-abb7-0f9f7d318b8d: [1,False,RM FRANCE - BA]
b: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
result: -1
a: 6ac05486-768c-40a5-8766-8f0495060cb1: [1,False,RM FRANCE - BA]
b: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
result: -1
a: 74a9c265-c5f4-4680-8080-ae4225b0b7f6: [1,False,RM FRANCE - BA]
b: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
result: -1
a: 78aa6a12-66a2-4d32-be5a-5af4449b093e: [1,False,RM FRANCE - BA]
b: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
result: -1
a: 91fbc8e5-4727-4e51-911e-1a2b9888e472: [1,False,RM FRANCE - BA]
b: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
result: -1
a: a75abd4c-23c5-466b-a308-e6ee070eb81b: [1,False,RM FRANCE - BA]
b: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
result: -1
a: ce725884-385c-4c0a-8928-426a910fb610: [1,False,RM FRANCE - BA]
b: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
result: -1
a: f8020843-9945-4e19-ace2-cd72886b8770: [1,False,RM FRANCE - BA]
b: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
result: -1
a: 02dc99c7-c1e1-414e-aff1-9443cbe02059: [1,False,RM GERMANY - BA]
b: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
result: -1
a: 0b2d8874-b265-45c6-be72-38251928d52b: [1,False,RM GERMANY - BA]
b: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
result: -1
a: 11c3fa14-b690-4c5b-9dfe-9d23eb753b36: [1,False,RM GERMANY - BA]
b: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
result: -1
a: 136d69ea-a372-46c2-bb82-61d300985850: [1,False,RM GERMANY - BA]
b: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
result: -1
a: 16397bf2-1430-4f32-92b6-c012c059de1c: [1,False,RM GERMANY - BA]
b: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
result: -1
a: 1a0a105e-323d-493a-a55b-cd496d8afd3a: [1,False,RM GERMANY - BA]
b: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
result: -1
a: 25a43ba8-76d8-4b59-9d36-fd8035dd646f: [1,False,RM GERMANY - BA]
b: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
result: -1
a: 35b8e8c3-b5ba-4b29-98a2-d25ae7cfce61: [1,False,RM GERMANY - BA]
b: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
result: -1
a: 390dc135-0db7-4601-86b2-4cffcf8fe739: [1,False,RM GERMANY - BA]
b: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
result: -1
a: 41cbd59b-42d9-4076-8aa1-bdbd37f54888: [1,False,RM GERMANY - BA]
b: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
result: -1
a: 42261f78-27d5-42c1-9768-8a98869c543b: [1,False,RM GERMANY - BA]
b: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
result: -1
a: 4fb4a868-30c5-4145-a37e-7239202eaa23: [1,False,RM GERMANY - BA]
b: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
result: -1
a: 6b5b93a6-a261-4f0d-8e8f-3900f2b70189: [1,False,RM GERMANY - BA]
b: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
result: -1
a: 784a058b-4a6e-4ec1-9304-5e6caf0db9b3: [1,False,RM GERMANY - BA]
b: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
result: -1
a: 7f3ee00f-94be-45da-a8ea-5be2ba5ab2cd: [1,False,RM GERMANY - BA]
b: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
result: -1
a: 8e9d9bcb-6199-43c0-a682-81f039b1532a: [1,False,RM GERMANY - BA]
b: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
result: -1
a: 94fe3793-0915-4843-9885-1ca33b7b27a9: [1,False,RM GERMANY - BA]
b: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
result: -1
a: 993b448f-9ab4-497b-b2d7-1ce338e882bd: [1,False,RM GERMANY - BA]
b: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
result: -1
a: 9cc03f44-0a25-492b-b59d-c4ae9fd7e30c: [1,False,RM GERMANY - BA]
b: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
result: -1
a: 8eb9bb08-4afd-457b-ad96-f0e93c1aebf1: [4,False,YODEL LOUNGER XXXL]
b: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
result: 1
a: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
b: c3850c89-d305-4a99-9e7f-1917400795a0: [4,False,XXL UK MAIN]
result: -1
a: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
b: 22879b7b-f3f9-45c9-88ad-41c0bfca93df: [4,False,XXL UK MAIN]
result: -1
a: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
b: b2a18851-9f95-4266-a669-fd3220738c35: [4,False,UK Mail Next Day - BA]
result: -1
a: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
b: f5edc9f3-0747-46b3-a623-92e9c58dd968: [4,False,RM MONTREAL - BA]
result: -1
a: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
b: 68abf144-2606-48e0-b84a-32018f937163: [4,False,RM ITALY - BA]
result: -1
a: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
b: 7a2eb7db-1dac-4e78-9e65-6b854913dbec: [4,False,RM GERMANY - BA]
result: -1
a: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
b: d1aa9fda-f0fa-44f8-a976-e58d75b65010: [4,False,RM FRANCE - BA]
result: -1
a: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
b: 83a5d510-b129-4a44-813f-fc42c1f05691: [4,False,RM FRANCE - BA]
result: -1
a: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
b: 3dbc8a0a-1fd2-4345-b503-7207343c3932: [4,False,DPD Next Day 12:00 - BA]
result: -1
a: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
b: fae33594-a087-4663-a81c-965324f60c82: [4,False,DPD Classic Expresspak - BA]
result: -1
a: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
b: 56b949a4-50cc-43dc-8628-ea5e223cecfe: [4,False,DPD Classic - BA]
result: -1
a: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
b: fce2463b-96dc-4201-86ac-643fa0928d88: [4,False,48T - PACKET - BA]
result: -1
a: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
b: f1774705-d517-4e9a-a500-75dcd3688ac5: [4,False,48T - PACKET - BA]
result: -1
a: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
b: cdb566da-4605-4145-8a76-c20931b27665: [4,False,UK Mail Next Day - BA]
result: -1
a: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
b: e6585a19-9220-484b-9389-27f6d7418629: [4,False,48T - PACKET - BA]
result: -1
a: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
b: c3a23121-879f-464f-836d-a4bf28a77a90: [4,False,48T - PACKET - BA]
result: -1
a: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
b: a17bc221-846a-4615-80e1-389d7f2f1976: [4,False,48T - PACKET - BA]
result: -1
a: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
b: 71b6dba8-e2cb-4e34-9677-e877e2dff31c: [4,False,48T - PACKET - BA]
result: -1
a: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
b: 608bf888-4b13-43a1-9339-293ca14af64b: [4,False,48T - PACKET - BA]
result: -1
a: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
b: 5ea587ec-22bd-4eb6-a357-aa4117a30a6f: [4,False,48T - PACKET - BA]
result: -1
a: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
b: 38f2068c-e6f0-44de-829c-dd08d320d8d4: [4,False,48T - PACKET - BA]
result: -1
a: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
b: 2c1cc50f-25fa-43a9-816b-b0eb74cc2ad4: [4,False,48T - PACKET - BA]
result: -1
a: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
b: 1d1677f1-debd-4297-bf33-013960ec6f6a: [4,False,48T - PACKET - BA]
result: -1
a: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
b: 0b3594f0-c632-4bf9-9592-bd777ce7605d: [4,False,48T - PACKET - BA]
result: -1
a: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
b: 3bc84e93-bbe1-4ba2-99c2-cd70dd385833: [4,False,3H - UK MAIN]
result: -1
a: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
b: fcf1f831-dee2-47a3-b2af-ee1e9678c733: [4,False,1H - UK MAIN]
result: -1
a: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
b: 81c0362b-3c4e-43ce-a3f6-5ac56c3032d7: [4,False,1H - UK MAIN]
result: -1
a: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
b: 7f942cf0-4815-4702-b0ad-b74794c7c100: [4,False,1H - UK MAIN]
result: -1
a: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
b: 5aa0e132-0345-4969-898e-6511a1175998: [4,False,1H - UK MAIN]
result: -1
a: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
b: 22c88bf4-e0f6-4ea0-8c70-aaaa0fd7cfb9: [4,False,1H - UK MAIN]
result: -1
a: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
b: b79958b6-e7ce-43b5-9d7e-b7d4e42fab92: [4,False,1H - BT]
result: -1
a: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
b: 7fa22520-c5fd-43f8-be05-c51d2f3edf21: [4,False,1H - BT]
result: -1
a: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
b: f563f11f-70e0-4620-bfaf-a57117c6f862: [1,False,YODEL LOUNGER XXXL]
result: -1
a: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
b: 16ba9df3-5f17-4e32-bcff-f2128bc74a64: [1,False,YODEL LOUNGER XXXL]
result: -1
a: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
b: a8297186-b743-4f44-abd4-99aa351f7b03: [1,False,XXL ISLE]
result: -1
a: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
b: e6879e85-beb2-41c0-a6ef-8419a9f93a2e: [1,False,UK Mail Next Day - XXL]
result: -1
a: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
b: b9ca8064-2f1e-400a-8b07-06819d36eaa8: [1,False,UK Mail Next Day - XXL]
result: -1
a: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
b: 426ae142-d93e-4217-82a5-16bedb0ba6b9: [1,False,UK Mail Next Day - XXL]
result: -1
a: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
b: f7b742f7-48be-4c1a-a041-3a09a0491642: [1,False,RM VANCOUVER - BA]
result: -1
a: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
b: e0f6b653-4633-4c0a-9282-7386838f3065: [1,False,RM VANCOUVER - BA]
result: -1
a: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
b: be4f788f-2720-4c2b-a7c7-e485f9749593: [1,False,RM VANCOUVER - BA]
result: -1
a: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
b: ad0745c9-4442-48f3-8e0c-3725323dbb28: [1,False,RM VANCOUVER - BA]
result: -1
a: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
b: 85c490a8-0983-42b1-9e9c-c9ff50cc1fb9: [1,False,RM VANCOUVER - BA]
result: -1
a: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
b: 731fa41e-864e-42b0-8624-5554f22c1ac4: [1,False,RM VANCOUVER - BA]
result: -1
a: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
b: 49518b34-7fc5-452d-8e85-dfc57362ea95: [1,False,RM VANCOUVER - BA]
result: -1
a: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
b: 4377f241-5b84-4e63-8fa6-19f0f0153474: [1,False,RM VANCOUVER - BA]
result: -1
a: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
b: 149419cf-f132-46e8-92be-784bcd93da43: [1,False,RM VANCOUVER - BA]
result: -1
a: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
b: 0f6fd091-ee3d-4773-a993-55735aef8119: [1,False,RM VANCOUVER - BA]
result: -1
a: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
b: dfe05612-1a06-4105-82dc-3bf8b750c5b5: [1,False,RM USSFOA - BA]
result: -1
a: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
b: 3239d4f9-0be1-4d26-a0c4-5e7dc6b2c076: [1,False,RM USSFOA - BA]
result: -1
a: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
b: 2b1a498f-f31b-4775-9d0c-a49c98637865: [1,False,RM USSFOA - BA]
result: -1
a: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
b: 0f99c3dc-df5c-4c1d-b710-9f9a9078da2c: [1,False,RM USSFOA - BA]
result: -1
a: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
b: c57f2005-a12e-43de-aef4-c950bfa6c624: [1,False,RM USORDA - BA]
result: -1
a: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
b: a0414290-a73d-4a26-8123-a6f4496660ab: [1,False,RM USORDA - BA]
result: -1
a: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
b: 92fdfff9-7343-4043-95d0-1be8d3e00774: [1,False,RM USORDA - BA]
result: -1
a: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
b: 6c52763e-badc-4d7e-9165-cae76d4d9d74: [1,False,RM USORDA - BA]
result: -1
a: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
b: 6179bb17-feef-44cc-8ec2-f9e640396847: [1,False,RM USORDA - BA]
result: -1
a: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
b: 4ec27f3a-1305-4897-a4cf-e8324944d25a: [1,False,RM USORDA - BA]
result: -1
a: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
b: 44c3277b-8c4c-47c9-b987-ed80b1c83380: [1,False,RM USORDA - BA]
result: -1
a: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
b: 208d0871-daf7-4169-b860-9bb516a995c0: [1,False,RM USORDA - BA]
result: -1
a: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
b: 1965ba6b-0156-4749-a1e3-4ed7a419d81c: [1,False,RM USORDA - BA]
result: -1
a: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
b: 0e4edb3b-5acb-4227-9b76-a91f297cc7f2: [1,False,RM USORDA - BA]
result: -1
a: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
b: 081860df-3349-4f17-bc87-14baab2ee3d2: [1,False,RM USORDA - BA]
result: -1
a: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
b: fbc883e4-e960-4769-85a8-0de06ea26069: [1,False,RM USLAXA - BA]
result: -1
a: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
b: f3e11631-dfc4-440d-96dc-f04fb7810127: [1,False,RM USLAXA - BA]
result: -1
a: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
b: 9eceff7d-816c-4908-9776-d1bea99a5cdc: [1,False,RM USLAXA - BA]
result: -1
a: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
b: 856a3a22-860c-4b4a-8a78-530006460ba4: [1,False,RM USLAXA - BA]
result: -1
a: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
b: 767ce763-3c60-42b7-96be-8c0e407f5500: [1,False,RM USLAXA - BA]
result: -1
a: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
b: 5cea72ec-d370-4d6a-ab1b-425bbe84d6c9: [1,False,RM USLAXA - BA]
result: -1
a: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
b: 49a8751a-41d9-4ccd-aace-29265a8eb7db: [1,False,RM USLAXA - BA]
result: -1
a: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
b: 1b814e9c-2706-4aa4-a105-2cdbc5e670fd: [1,False,RM USLAXA - BA]
result: -1
a: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
b: 0ff80f3b-a91e-4357-ba86-b339d9a7488c: [1,False,RM USLAXA - BA]
result: -1
a: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
b: eaae3178-be80-420b-858d-031a7af23f26: [1,False,RM USJFKA - BA]
result: -1
a: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
b: e870ebf5-af6e-4764-a89c-2deab5e9728c: [1,False,RM USJFKA - BA]
result: -1
a: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
b: c6efa935-448a-46f5-939e-83672b195102: [1,False,RM USJFKA - BA]
result: -1
a: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
b: c6629e65-823e-4048-9877-8bbf1a3e5a77: [1,False,RM USJFKA - BA]
result: -1
a: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
b: c548b03d-45ca-4b83-ac8f-205eef8be17c: [1,False,RM USJFKA - BA]
result: -1
a: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
b: bfbd81e6-100e-441a-81ea-590a81d3bc3f: [1,False,RM USJFKA - BA]
result: -1
a: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
b: a45a07b5-ba2e-4a09-b3d4-5c897c7a6d7a: [1,False,RM USJFKA - BA]
result: -1
a: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
b: a2a92676-0f19-4f39-89e7-92dbb4c1de48: [1,False,RM USJFKA - BA]
result: -1
a: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
b: 8eb695d7-5773-4c63-aec2-76f874fb4076: [1,False,RM USJFKA - BA]
result: -1
a: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
b: 8b7f596e-f203-4a77-bdb8-711f462c117d: [1,False,RM USJFKA - BA]
result: -1
a: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
b: 83c0c531-ca32-4cec-802d-2b7ad9fecd3a: [1,False,RM USJFKA - BA]
result: -1
a: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
b: 764df177-0d69-47e4-9aa1-c8ba495ab412: [1,False,RM USJFKA - BA]
result: -1
a: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
b: 5a3d2010-0816-4613-9b9e-63afd94312b2: [1,False,RM USJFKA - BA]
result: -1
a: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
b: 569b232f-fe59-455c-a38b-6e80b9e1cd2b: [1,False,RM USJFKA - BA]
result: -1
a: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
b: 4702eb62-a473-4bc2-adf7-effb2619480f: [1,False,RM USJFKA - BA]
result: -1
a: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
b: 2e855f49-0d8c-42a3-aa53-05edfc72bb81: [1,False,RM USJFKA - BA]
result: -1
a: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
b: 22a236e1-3da8-44f9-b853-f508913641b7: [1,False,RM USJFKA - BA]
result: -1
a: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
b: 17ddbe7b-0f83-40d8-916d-9ce0beb4ab0b: [1,False,RM USJFKA - BA]
result: -1
a: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
b: f9bb4176-4033-4faf-8681-269e8375d79a: [1,False,RM TORONTO-A - BA]
result: -1
a: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
b: f0d94469-7c3f-4780-89f7-17bf97b8af88: [1,False,RM TORONTO-A - BA]
result: -1
a: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
b: e1c69b5a-2711-4584-bd9a-555395804082: [1,False,RM TORONTO-A - BA]
result: -1
a: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
b: e0b9405c-a4b3-43a5-87d1-f98c878c4ac3: [1,False,RM TORONTO-A - BA]
result: -1
a: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
b: d9b1fea0-a484-4b02-b46b-99b7c95ac8a5: [1,False,RM TORONTO-A - BA]
result: -1
a: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
b: d614a12b-87a7-46ce-93c7-afd837d8e084: [1,False,RM TORONTO-A - BA]
result: -1
a: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
b: bc4ac6d1-bd45-4982-8067-00de502afe55: [1,False,RM TORONTO-A - BA]
result: -1
a: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
b: bae0caa1-93eb-4be4-a62c-dfdf4a2ff419: [1,False,RM TORONTO-A - BA]
result: -1
a: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
b: a318a335-5fba-4df5-adcf-bb2cb3bbefbc: [1,False,RM TORONTO-A - BA]
result: -1
a: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
b: 8c2431c9-d770-4ee0-9ebb-e5dc8683974b: [1,False,RM TORONTO-A - BA]
result: -1
a: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
b: 6c10ff57-21d6-4dfb-b397-5a4515284bc5: [1,False,RM TORONTO-A - BA]
result: -1
a: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
b: dcd165ec-01f2-4085-9f9b-542ed7725087: [1,False,RM SYDNEY - BA]
result: -1
a: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
b: cb5d78e2-bdc6-43ae-b016-7e55ec724c31: [1,False,RM SYDNEY - BA]
result: -1
a: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
b: ba02a597-7863-402c-87f5-87cedc62e7d5: [1,False,RM SYDNEY - BA]
result: -1
a: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
b: b41fc4a6-837e-4909-ba9d-54399d40ca5e: [1,False,RM SYDNEY - BA]
result: -1
a: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
b: b1521865-b4eb-4583-8bfb-fbd5ead6bd42: [1,False,RM SYDNEY - BA]
result: -1
a: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
b: af7e76a1-141b-46b6-a8a5-cf04bb40c8ce: [1,False,RM SYDNEY - BA]
result: -1
a: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
b: adccd665-00aa-4e72-83ac-aa8b7a291850: [1,False,RM SYDNEY - BA]
result: -1
a: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
b: 2ae36886-7696-4c1b-9f81-112d2d1a66c5: [1,False,RM SYDNEY - BA]
result: -1
a: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
b: f9376c81-d3c8-424c-aa48-f7ab73831c02: [1,False,RM SPAIN - BA]
result: -1
a: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
b: a67d5cf9-fcfb-4f8f-91c0-8194cf1eb0b4: [1,False,RM SPAIN - BA]
result: -1
a: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
b: 9c0f7656-4ac4-4fb3-8656-2808b11f340e: [1,False,RM SPAIN - BA]
result: -1
a: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
b: 919d9751-bc26-4367-827d-d4964f5344d7: [1,False,RM SPAIN - BA]
result: -1
a: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
b: 2c6d8e2f-39be-4023-bef8-06c19c4afe55: [1,False,RM SPAIN - BA]
result: -1
a: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
b: a428dcb9-c13a-4bec-9ffd-c9cf379f563b: [1,False,RM REST OF EUROPE - BA]
result: -1
a: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
b: 6b9fad4d-b2e2-4b5f-af82-6cdfa187420c: [1,False,RM REST OF EUROPE - BA]
result: -1
a: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
b: 536f9023-0696-43a1-ad08-51019e63feb0: [1,False,RM REST OF EUROPE - BA]
result: -1
a: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
b: 0b490240-d7e4-42cc-a2a0-2399aafd82e5: [1,False,RM REST OF EUROPE - BA]
result: -1
a: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
b: d891bcdb-8e2a-4a06-a971-87e61e32e619: [1,False,RM MONTREAL - BA]
result: -1
a: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
b: cfd60973-54ba-459b-a6d2-5a9dd753e2cc: [1,False,RM MONTREAL - BA]
result: -1
a: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
b: 750818f1-0a46-4955-a2d6-4861e4c9801f: [1,False,RM MONTREAL - BA]
result: -1
a: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
b: 735f16c3-daeb-4167-b39e-a7b341cc030e: [1,False,RM MONTREAL - BA]
result: -1
a: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
b: 449d79e6-0018-4ec0-ab0b-e204dbc08819: [1,False,RM MONTREAL - BA]
result: -1
a: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
b: 42ffb822-5e16-4760-b7d8-115d253c058b: [1,False,RM MONTREAL - BA]
result: -1
a: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
b: 10cf2066-c155-41d6-badb-9a172a521b56: [1,False,RM MONTREAL - BA]
result: -1
a: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
b: 718962b1-b0cd-4591-bd82-71e364a87837: [1,False,RM MONTREAL]
result: -1
a: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
b: f554beb2-ad59-483d-bb55-75e733bcd8d0: [1,False,RM ITALY - BA]
result: -1
a: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
b: ce75038a-426a-4655-8752-c802564f20e2: [1,False,RM ITALY - BA]
result: -1
a: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
b: 9e567a9b-16f4-4c57-9c83-786d1366b956: [1,False,RM ITALY - BA]
result: -1
a: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
b: 9d8abf88-49de-4066-978c-0f94e778a1af: [1,False,RM ITALY - BA]
result: -1
a: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
b: 7da61c05-bfe1-4837-b5d1-e8d750b80af9: [1,False,RM ITALY - BA]
result: -1
a: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
b: 6a338913-66d6-409f-b542-8b7427066360: [1,False,RM ITALY - BA]
result: -1
a: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
b: 611c46c3-c3ff-49c8-8cc9-6055af127963: [1,False,RM ITALY - BA]
result: -1
a: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
b: 59f65080-3ecd-44fa-b096-2f1ab1a2c4a9: [1,False,RM ITALY - BA]
result: -1
a: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
b: 51316976-bf3e-480a-ad33-ddf0f060b381: [1,False,RM ITALY - BA]
result: -1
a: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
b: 509ee8ea-770a-47d8-a454-188cc82d8748: [1,False,RM ITALY - BA]
result: -1
a: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
b: 4056d60b-445a-471b-bce6-2db16ef6d709: [1,False,RM ITALY - BA]
result: -1
a: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
b: 32ae31ae-7331-4777-a637-d5d9e158c001: [1,False,RM ITALY - BA]
result: -1
a: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
b: 0870a621-0a12-4946-a92f-954beaa132d4: [1,False,RM ITALY - BA]
result: -1
a: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
b: 07748c81-5348-4465-b8a6-3f551afa3bf5: [1,False,RM IRELAND - BA]
result: -1
a: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
b: ff60d13a-2cc9-41b3-ba9a-a665be1fdbc8: [1,False,RM GERMANY - BA]
result: -1
a: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
b: f8ba09e7-5f09-413c-9491-025124542c95: [1,False,RM GERMANY - BA]
result: -1
a: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
b: dcfa85bc-b9a9-4382-b090-d40f2d207ecf: [1,False,RM GERMANY - BA]
result: -1
a: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
b: d8983815-5402-460a-9ddb-472c49f42e0d: [1,False,RM GERMANY - BA]
result: -1
a: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
b: cec806f1-0671-4b0d-b922-c004b92b3c70: [1,False,RM GERMANY - BA]
result: -1
a: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
b: ce3a00a0-f9e0-4c7d-b663-02485f9b1089: [1,False,RM GERMANY - BA]
result: -1
a: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
b: bf692f58-002b-4fa9-9d07-23149b4ad9f7: [1,False,RM GERMANY - BA]
result: -1
a: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
b: bd173af2-34ce-4aab-b93a-e7c7d21d3302: [1,False,RM GERMANY - BA]
result: -1
a: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
b: bb68938d-b94a-42fc-aa3b-c1207781a44b: [1,False,RM GERMANY - BA]
result: -1
a: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
b: adb5b22f-d513-4a7a-8f15-97a21f63d371: [1,False,RM GERMANY - BA]
result: -1
a: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
b: 8eb9bb08-4afd-457b-ad96-f0e93c1aebf1: [4,False,YODEL LOUNGER XXXL]
result: -1
a: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
b: 9cc03f44-0a25-492b-b59d-c4ae9fd7e30c: [1,False,RM GERMANY - BA]
result: 1
a: adb5b22f-d513-4a7a-8f15-97a21f63d371: [1,False,RM GERMANY - BA]
b: c6efa935-448a-46f5-939e-83672b195102: [1,False,RM USJFKA - BA]
result: -1
a: adb5b22f-d513-4a7a-8f15-97a21f63d371: [1,False,RM GERMANY - BA]
b: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
result: -1
a: c6efa935-448a-46f5-939e-83672b195102: [1,False,RM USJFKA - BA]
b: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
result: -1
a: bb68938d-b94a-42fc-aa3b-c1207781a44b: [1,False,RM GERMANY - BA]
b: c6efa935-448a-46f5-939e-83672b195102: [1,False,RM USJFKA - BA]
result: -1
a: bd173af2-34ce-4aab-b93a-e7c7d21d3302: [1,False,RM GERMANY - BA]
b: c6efa935-448a-46f5-939e-83672b195102: [1,False,RM USJFKA - BA]
result: -1
a: bf692f58-002b-4fa9-9d07-23149b4ad9f7: [1,False,RM GERMANY - BA]
b: c6efa935-448a-46f5-939e-83672b195102: [1,False,RM USJFKA - BA]
result: -1
a: ce3a00a0-f9e0-4c7d-b663-02485f9b1089: [1,False,RM GERMANY - BA]
b: c6efa935-448a-46f5-939e-83672b195102: [1,False,RM USJFKA - BA]
result: -1
a: cec806f1-0671-4b0d-b922-c004b92b3c70: [1,False,RM GERMANY - BA]
b: c6efa935-448a-46f5-939e-83672b195102: [1,False,RM USJFKA - BA]
result: -1
a: d8983815-5402-460a-9ddb-472c49f42e0d: [1,False,RM GERMANY - BA]
b: c6efa935-448a-46f5-939e-83672b195102: [1,False,RM USJFKA - BA]
result: -1
a: dcfa85bc-b9a9-4382-b090-d40f2d207ecf: [1,False,RM GERMANY - BA]
b: c6efa935-448a-46f5-939e-83672b195102: [1,False,RM USJFKA - BA]
result: -1
a: f8ba09e7-5f09-413c-9491-025124542c95: [1,False,RM GERMANY - BA]
b: c6efa935-448a-46f5-939e-83672b195102: [1,False,RM USJFKA - BA]
result: -1
a: ff60d13a-2cc9-41b3-ba9a-a665be1fdbc8: [1,False,RM GERMANY - BA]
b: c6efa935-448a-46f5-939e-83672b195102: [1,False,RM USJFKA - BA]
result: -1
a: 07748c81-5348-4465-b8a6-3f551afa3bf5: [1,False,RM IRELAND - BA]
b: c6efa935-448a-46f5-939e-83672b195102: [1,False,RM USJFKA - BA]
result: -1
a: 0870a621-0a12-4946-a92f-954beaa132d4: [1,False,RM ITALY - BA]
b: c6efa935-448a-46f5-939e-83672b195102: [1,False,RM USJFKA - BA]
result: -1
a: 32ae31ae-7331-4777-a637-d5d9e158c001: [1,False,RM ITALY - BA]
b: c6efa935-448a-46f5-939e-83672b195102: [1,False,RM USJFKA - BA]
result: -1
a: 4056d60b-445a-471b-bce6-2db16ef6d709: [1,False,RM ITALY - BA]
b: c6efa935-448a-46f5-939e-83672b195102: [1,False,RM USJFKA - BA]
result: -1
a: 509ee8ea-770a-47d8-a454-188cc82d8748: [1,False,RM ITALY - BA]
b: c6efa935-448a-46f5-939e-83672b195102: [1,False,RM USJFKA - BA]
result: -1
a: 51316976-bf3e-480a-ad33-ddf0f060b381: [1,False,RM ITALY - BA]
b: c6efa935-448a-46f5-939e-83672b195102: [1,False,RM USJFKA - BA]
result: -1
a: 59f65080-3ecd-44fa-b096-2f1ab1a2c4a9: [1,False,RM ITALY - BA]
b: c6efa935-448a-46f5-939e-83672b195102: [1,False,RM USJFKA - BA]
result: -1
a: 611c46c3-c3ff-49c8-8cc9-6055af127963: [1,False,RM ITALY - BA]
b: c6efa935-448a-46f5-939e-83672b195102: [1,False,RM USJFKA - BA]
result: -1
a: 6a338913-66d6-409f-b542-8b7427066360: [1,False,RM ITALY - BA]
b: c6efa935-448a-46f5-939e-83672b195102: [1,False,RM USJFKA - BA]
result: -1
a: 7da61c05-bfe1-4837-b5d1-e8d750b80af9: [1,False,RM ITALY - BA]
b: c6efa935-448a-46f5-939e-83672b195102: [1,False,RM USJFKA - BA]
result: -1
a: 9d8abf88-49de-4066-978c-0f94e778a1af: [1,False,RM ITALY - BA]
b: c6efa935-448a-46f5-939e-83672b195102: [1,False,RM USJFKA - BA]
result: -1
a: 9e567a9b-16f4-4c57-9c83-786d1366b956: [1,False,RM ITALY - BA]
b: c6efa935-448a-46f5-939e-83672b195102: [1,False,RM USJFKA - BA]
result: -1
a: ce75038a-426a-4655-8752-c802564f20e2: [1,False,RM ITALY - BA]
b: c6efa935-448a-46f5-939e-83672b195102: [1,False,RM USJFKA - BA]
result: -1
a: f554beb2-ad59-483d-bb55-75e733bcd8d0: [1,False,RM ITALY - BA]
b: c6efa935-448a-46f5-939e-83672b195102: [1,False,RM USJFKA - BA]
result: -1
a: 718962b1-b0cd-4591-bd82-71e364a87837: [1,False,RM MONTREAL]
b: c6efa935-448a-46f5-939e-83672b195102: [1,False,RM USJFKA - BA]
result: -1
a: 10cf2066-c155-41d6-badb-9a172a521b56: [1,False,RM MONTREAL - BA]
b: c6efa935-448a-46f5-939e-83672b195102: [1,False,RM USJFKA - BA]
result: -1
a: 42ffb822-5e16-4760-b7d8-115d253c058b: [1,False,RM MONTREAL - BA]
b: c6efa935-448a-46f5-939e-83672b195102: [1,False,RM USJFKA - BA]
result: -1
a: 449d79e6-0018-4ec0-ab0b-e204dbc08819: [1,False,RM MONTREAL - BA]
b: c6efa935-448a-46f5-939e-83672b195102: [1,False,RM USJFKA - BA]
result: -1
a: 735f16c3-daeb-4167-b39e-a7b341cc030e: [1,False,RM MONTREAL - BA]
b: c6efa935-448a-46f5-939e-83672b195102: [1,False,RM USJFKA - BA]
result: -1
a: 750818f1-0a46-4955-a2d6-4861e4c9801f: [1,False,RM MONTREAL - BA]
b: c6efa935-448a-46f5-939e-83672b195102: [1,False,RM USJFKA - BA]
result: -1
a: cfd60973-54ba-459b-a6d2-5a9dd753e2cc: [1,False,RM MONTREAL - BA]
b: c6efa935-448a-46f5-939e-83672b195102: [1,False,RM USJFKA - BA]
result: -1
a: d891bcdb-8e2a-4a06-a971-87e61e32e619: [1,False,RM MONTREAL - BA]
b: c6efa935-448a-46f5-939e-83672b195102: [1,False,RM USJFKA - BA]
result: -1
a: 0b490240-d7e4-42cc-a2a0-2399aafd82e5: [1,False,RM REST OF EUROPE - BA]
b: c6efa935-448a-46f5-939e-83672b195102: [1,False,RM USJFKA - BA]
result: -1
a: 536f9023-0696-43a1-ad08-51019e63feb0: [1,False,RM REST OF EUROPE - BA]
b: c6efa935-448a-46f5-939e-83672b195102: [1,False,RM USJFKA - BA]
result: -1
a: 6b9fad4d-b2e2-4b5f-af82-6cdfa187420c: [1,False,RM REST OF EUROPE - BA]
b: c6efa935-448a-46f5-939e-83672b195102: [1,False,RM USJFKA - BA]
result: -1
a: a428dcb9-c13a-4bec-9ffd-c9cf379f563b: [1,False,RM REST OF EUROPE - BA]
b: c6efa935-448a-46f5-939e-83672b195102: [1,False,RM USJFKA - BA]
result: -1
a: 2c6d8e2f-39be-4023-bef8-06c19c4afe55: [1,False,RM SPAIN - BA]
b: c6efa935-448a-46f5-939e-83672b195102: [1,False,RM USJFKA - BA]
result: -1
a: 919d9751-bc26-4367-827d-d4964f5344d7: [1,False,RM SPAIN - BA]
b: c6efa935-448a-46f5-939e-83672b195102: [1,False,RM USJFKA - BA]
result: -1
a: 9c0f7656-4ac4-4fb3-8656-2808b11f340e: [1,False,RM SPAIN - BA]
b: c6efa935-448a-46f5-939e-83672b195102: [1,False,RM USJFKA - BA]
result: -1
a: a67d5cf9-fcfb-4f8f-91c0-8194cf1eb0b4: [1,False,RM SPAIN - BA]
b: c6efa935-448a-46f5-939e-83672b195102: [1,False,RM USJFKA - BA]
result: -1
a: f9376c81-d3c8-424c-aa48-f7ab73831c02: [1,False,RM SPAIN - BA]
b: c6efa935-448a-46f5-939e-83672b195102: [1,False,RM USJFKA - BA]
result: -1
a: 2ae36886-7696-4c1b-9f81-112d2d1a66c5: [1,False,RM SYDNEY - BA]
b: c6efa935-448a-46f5-939e-83672b195102: [1,False,RM USJFKA - BA]
result: -1
a: adccd665-00aa-4e72-83ac-aa8b7a291850: [1,False,RM SYDNEY - BA]
b: c6efa935-448a-46f5-939e-83672b195102: [1,False,RM USJFKA - BA]
result: -1
a: af7e76a1-141b-46b6-a8a5-cf04bb40c8ce: [1,False,RM SYDNEY - BA]
b: c6efa935-448a-46f5-939e-83672b195102: [1,False,RM USJFKA - BA]
result: -1
a: b1521865-b4eb-4583-8bfb-fbd5ead6bd42: [1,False,RM SYDNEY - BA]
b: c6efa935-448a-46f5-939e-83672b195102: [1,False,RM USJFKA - BA]
result: -1
a: b41fc4a6-837e-4909-ba9d-54399d40ca5e: [1,False,RM SYDNEY - BA]
b: c6efa935-448a-46f5-939e-83672b195102: [1,False,RM USJFKA - BA]
result: -1
a: ba02a597-7863-402c-87f5-87cedc62e7d5: [1,False,RM SYDNEY - BA]
b: c6efa935-448a-46f5-939e-83672b195102: [1,False,RM USJFKA - BA]
result: -1
a: cb5d78e2-bdc6-43ae-b016-7e55ec724c31: [1,False,RM SYDNEY - BA]
b: c6efa935-448a-46f5-939e-83672b195102: [1,False,RM USJFKA - BA]
result: -1
a: dcd165ec-01f2-4085-9f9b-542ed7725087: [1,False,RM SYDNEY - BA]
b: c6efa935-448a-46f5-939e-83672b195102: [1,False,RM USJFKA - BA]
result: -1
a: 6c10ff57-21d6-4dfb-b397-5a4515284bc5: [1,False,RM TORONTO-A - BA]
b: c6efa935-448a-46f5-939e-83672b195102: [1,False,RM USJFKA - BA]
result: -1
a: 8c2431c9-d770-4ee0-9ebb-e5dc8683974b: [1,False,RM TORONTO-A - BA]
b: c6efa935-448a-46f5-939e-83672b195102: [1,False,RM USJFKA - BA]
result: -1
a: a318a335-5fba-4df5-adcf-bb2cb3bbefbc: [1,False,RM TORONTO-A - BA]
b: c6efa935-448a-46f5-939e-83672b195102: [1,False,RM USJFKA - BA]
result: -1
a: bae0caa1-93eb-4be4-a62c-dfdf4a2ff419: [1,False,RM TORONTO-A - BA]
b: c6efa935-448a-46f5-939e-83672b195102: [1,False,RM USJFKA - BA]
result: -1
a: bc4ac6d1-bd45-4982-8067-00de502afe55: [1,False,RM TORONTO-A - BA]
b: c6efa935-448a-46f5-939e-83672b195102: [1,False,RM USJFKA - BA]
result: -1
a: d614a12b-87a7-46ce-93c7-afd837d8e084: [1,False,RM TORONTO-A - BA]
b: c6efa935-448a-46f5-939e-83672b195102: [1,False,RM USJFKA - BA]
result: -1
a: d9b1fea0-a484-4b02-b46b-99b7c95ac8a5: [1,False,RM TORONTO-A - BA]
b: c6efa935-448a-46f5-939e-83672b195102: [1,False,RM USJFKA - BA]
result: -1
a: e0b9405c-a4b3-43a5-87d1-f98c878c4ac3: [1,False,RM TORONTO-A - BA]
b: c6efa935-448a-46f5-939e-83672b195102: [1,False,RM USJFKA - BA]
result: -1
a: e1c69b5a-2711-4584-bd9a-555395804082: [1,False,RM TORONTO-A - BA]
b: c6efa935-448a-46f5-939e-83672b195102: [1,False,RM USJFKA - BA]
result: -1
a: f0d94469-7c3f-4780-89f7-17bf97b8af88: [1,False,RM TORONTO-A - BA]
b: c6efa935-448a-46f5-939e-83672b195102: [1,False,RM USJFKA - BA]
result: -1
a: f9bb4176-4033-4faf-8681-269e8375d79a: [1,False,RM TORONTO-A - BA]
b: c6efa935-448a-46f5-939e-83672b195102: [1,False,RM USJFKA - BA]
result: -1
a: 17ddbe7b-0f83-40d8-916d-9ce0beb4ab0b: [1,False,RM USJFKA - BA]
b: c6efa935-448a-46f5-939e-83672b195102: [1,False,RM USJFKA - BA]
result: -1
a: 22a236e1-3da8-44f9-b853-f508913641b7: [1,False,RM USJFKA - BA]
b: c6efa935-448a-46f5-939e-83672b195102: [1,False,RM USJFKA - BA]
result: -1
a: 2e855f49-0d8c-42a3-aa53-05edfc72bb81: [1,False,RM USJFKA - BA]
b: c6efa935-448a-46f5-939e-83672b195102: [1,False,RM USJFKA - BA]
result: -1
a: 4702eb62-a473-4bc2-adf7-effb2619480f: [1,False,RM USJFKA - BA]
b: c6efa935-448a-46f5-939e-83672b195102: [1,False,RM USJFKA - BA]
result: -1
a: 569b232f-fe59-455c-a38b-6e80b9e1cd2b: [1,False,RM USJFKA - BA]
b: c6efa935-448a-46f5-939e-83672b195102: [1,False,RM USJFKA - BA]
result: -1
a: 5a3d2010-0816-4613-9b9e-63afd94312b2: [1,False,RM USJFKA - BA]
b: c6efa935-448a-46f5-939e-83672b195102: [1,False,RM USJFKA - BA]
result: -1
a: 764df177-0d69-47e4-9aa1-c8ba495ab412: [1,False,RM USJFKA - BA]
b: c6efa935-448a-46f5-939e-83672b195102: [1,False,RM USJFKA - BA]
result: -1
a: 83c0c531-ca32-4cec-802d-2b7ad9fecd3a: [1,False,RM USJFKA - BA]
b: c6efa935-448a-46f5-939e-83672b195102: [1,False,RM USJFKA - BA]
result: -1
a: 8b7f596e-f203-4a77-bdb8-711f462c117d: [1,False,RM USJFKA - BA]
b: c6efa935-448a-46f5-939e-83672b195102: [1,False,RM USJFKA - BA]
result: -1
a: 8eb695d7-5773-4c63-aec2-76f874fb4076: [1,False,RM USJFKA - BA]
b: c6efa935-448a-46f5-939e-83672b195102: [1,False,RM USJFKA - BA]
result: -1
a: a2a92676-0f19-4f39-89e7-92dbb4c1de48: [1,False,RM USJFKA - BA]
b: c6efa935-448a-46f5-939e-83672b195102: [1,False,RM USJFKA - BA]
result: -1
a: a45a07b5-ba2e-4a09-b3d4-5c897c7a6d7a: [1,False,RM USJFKA - BA]
b: c6efa935-448a-46f5-939e-83672b195102: [1,False,RM USJFKA - BA]
result: -1
a: bfbd81e6-100e-441a-81ea-590a81d3bc3f: [1,False,RM USJFKA - BA]
b: c6efa935-448a-46f5-939e-83672b195102: [1,False,RM USJFKA - BA]
result: -1
a: c548b03d-45ca-4b83-ac8f-205eef8be17c: [1,False,RM USJFKA - BA]
b: c6efa935-448a-46f5-939e-83672b195102: [1,False,RM USJFKA - BA]
result: -1
a: c6629e65-823e-4048-9877-8bbf1a3e5a77: [1,False,RM USJFKA - BA]
b: c6efa935-448a-46f5-939e-83672b195102: [1,False,RM USJFKA - BA]
result: -1
a: 8eb9bb08-4afd-457b-ad96-f0e93c1aebf1: [4,False,YODEL LOUNGER XXXL]
b: c6efa935-448a-46f5-939e-83672b195102: [1,False,RM USJFKA - BA]
result: 1
a: c6efa935-448a-46f5-939e-83672b195102: [1,False,RM USJFKA - BA]
b: c3850c89-d305-4a99-9e7f-1917400795a0: [4,False,XXL UK MAIN]
result: -1
a: c6efa935-448a-46f5-939e-83672b195102: [1,False,RM USJFKA - BA]
b: 22879b7b-f3f9-45c9-88ad-41c0bfca93df: [4,False,XXL UK MAIN]
result: -1
a: c6efa935-448a-46f5-939e-83672b195102: [1,False,RM USJFKA - BA]
b: b2a18851-9f95-4266-a669-fd3220738c35: [4,False,UK Mail Next Day - BA]
result: -1
a: c6efa935-448a-46f5-939e-83672b195102: [1,False,RM USJFKA - BA]
b: f5edc9f3-0747-46b3-a623-92e9c58dd968: [4,False,RM MONTREAL - BA]
result: -1
a: c6efa935-448a-46f5-939e-83672b195102: [1,False,RM USJFKA - BA]
b: 68abf144-2606-48e0-b84a-32018f937163: [4,False,RM ITALY - BA]
result: -1
a: c6efa935-448a-46f5-939e-83672b195102: [1,False,RM USJFKA - BA]
b: 7a2eb7db-1dac-4e78-9e65-6b854913dbec: [4,False,RM GERMANY - BA]
result: -1
a: c6efa935-448a-46f5-939e-83672b195102: [1,False,RM USJFKA - BA]
b: d1aa9fda-f0fa-44f8-a976-e58d75b65010: [4,False,RM FRANCE - BA]
result: -1
a: c6efa935-448a-46f5-939e-83672b195102: [1,False,RM USJFKA - BA]
b: 83a5d510-b129-4a44-813f-fc42c1f05691: [4,False,RM FRANCE - BA]
result: -1
a: c6efa935-448a-46f5-939e-83672b195102: [1,False,RM USJFKA - BA]
b: 3dbc8a0a-1fd2-4345-b503-7207343c3932: [4,False,DPD Next Day 12:00 - BA]
result: -1
a: c6efa935-448a-46f5-939e-83672b195102: [1,False,RM USJFKA - BA]
b: fae33594-a087-4663-a81c-965324f60c82: [4,False,DPD Classic Expresspak - BA]
result: -1
a: c6efa935-448a-46f5-939e-83672b195102: [1,False,RM USJFKA - BA]
b: 56b949a4-50cc-43dc-8628-ea5e223cecfe: [4,False,DPD Classic - BA]
result: -1
a: c6efa935-448a-46f5-939e-83672b195102: [1,False,RM USJFKA - BA]
b: fce2463b-96dc-4201-86ac-643fa0928d88: [4,False,48T - PACKET - BA]
result: -1
a: c6efa935-448a-46f5-939e-83672b195102: [1,False,RM USJFKA - BA]
b: f1774705-d517-4e9a-a500-75dcd3688ac5: [4,False,48T - PACKET - BA]
result: -1
a: c6efa935-448a-46f5-939e-83672b195102: [1,False,RM USJFKA - BA]
b: cdb566da-4605-4145-8a76-c20931b27665: [4,False,UK Mail Next Day - BA]
result: -1
a: c6efa935-448a-46f5-939e-83672b195102: [1,False,RM USJFKA - BA]
b: e6585a19-9220-484b-9389-27f6d7418629: [4,False,48T - PACKET - BA]
result: -1
a: c6efa935-448a-46f5-939e-83672b195102: [1,False,RM USJFKA - BA]
b: c3a23121-879f-464f-836d-a4bf28a77a90: [4,False,48T - PACKET - BA]
result: -1
a: c6efa935-448a-46f5-939e-83672b195102: [1,False,RM USJFKA - BA]
b: a17bc221-846a-4615-80e1-389d7f2f1976: [4,False,48T - PACKET - BA]
result: -1
a: c6efa935-448a-46f5-939e-83672b195102: [1,False,RM USJFKA - BA]
b: 71b6dba8-e2cb-4e34-9677-e877e2dff31c: [4,False,48T - PACKET - BA]
result: -1
a: c6efa935-448a-46f5-939e-83672b195102: [1,False,RM USJFKA - BA]
b: 608bf888-4b13-43a1-9339-293ca14af64b: [4,False,48T - PACKET - BA]
result: -1
a: c6efa935-448a-46f5-939e-83672b195102: [1,False,RM USJFKA - BA]
b: 5ea587ec-22bd-4eb6-a357-aa4117a30a6f: [4,False,48T - PACKET - BA]
result: -1
a: c6efa935-448a-46f5-939e-83672b195102: [1,False,RM USJFKA - BA]
b: 38f2068c-e6f0-44de-829c-dd08d320d8d4: [4,False,48T - PACKET - BA]
result: -1
a: c6efa935-448a-46f5-939e-83672b195102: [1,False,RM USJFKA - BA]
b: 2c1cc50f-25fa-43a9-816b-b0eb74cc2ad4: [4,False,48T - PACKET - BA]
result: -1
a: c6efa935-448a-46f5-939e-83672b195102: [1,False,RM USJFKA - BA]
b: 1d1677f1-debd-4297-bf33-013960ec6f6a: [4,False,48T - PACKET - BA]
result: -1
a: c6efa935-448a-46f5-939e-83672b195102: [1,False,RM USJFKA - BA]
b: 0b3594f0-c632-4bf9-9592-bd777ce7605d: [4,False,48T - PACKET - BA]
result: -1
a: c6efa935-448a-46f5-939e-83672b195102: [1,False,RM USJFKA - BA]
b: 3bc84e93-bbe1-4ba2-99c2-cd70dd385833: [4,False,3H - UK MAIN]
result: -1
a: c6efa935-448a-46f5-939e-83672b195102: [1,False,RM USJFKA - BA]
b: fcf1f831-dee2-47a3-b2af-ee1e9678c733: [4,False,1H - UK MAIN]
result: -1
a: c6efa935-448a-46f5-939e-83672b195102: [1,False,RM USJFKA - BA]
b: 81c0362b-3c4e-43ce-a3f6-5ac56c3032d7: [4,False,1H - UK MAIN]
result: -1
a: c6efa935-448a-46f5-939e-83672b195102: [1,False,RM USJFKA - BA]
b: 7f942cf0-4815-4702-b0ad-b74794c7c100: [4,False,1H - UK MAIN]
result: -1
a: c6efa935-448a-46f5-939e-83672b195102: [1,False,RM USJFKA - BA]
b: 5aa0e132-0345-4969-898e-6511a1175998: [4,False,1H - UK MAIN]
result: -1
a: c6efa935-448a-46f5-939e-83672b195102: [1,False,RM USJFKA - BA]
b: 22c88bf4-e0f6-4ea0-8c70-aaaa0fd7cfb9: [4,False,1H - UK MAIN]
result: -1
a: c6efa935-448a-46f5-939e-83672b195102: [1,False,RM USJFKA - BA]
b: b79958b6-e7ce-43b5-9d7e-b7d4e42fab92: [4,False,1H - BT]
result: -1
a: c6efa935-448a-46f5-939e-83672b195102: [1,False,RM USJFKA - BA]
b: 7fa22520-c5fd-43f8-be05-c51d2f3edf21: [4,False,1H - BT]
result: -1
a: c6efa935-448a-46f5-939e-83672b195102: [1,False,RM USJFKA - BA]
b: f563f11f-70e0-4620-bfaf-a57117c6f862: [1,False,YODEL LOUNGER XXXL]
result: -1
a: c6efa935-448a-46f5-939e-83672b195102: [1,False,RM USJFKA - BA]
b: 16ba9df3-5f17-4e32-bcff-f2128bc74a64: [1,False,YODEL LOUNGER XXXL]
result: -1
a: c6efa935-448a-46f5-939e-83672b195102: [1,False,RM USJFKA - BA]
b: a8297186-b743-4f44-abd4-99aa351f7b03: [1,False,XXL ISLE]
result: -1
a: c6efa935-448a-46f5-939e-83672b195102: [1,False,RM USJFKA - BA]
b: e6879e85-beb2-41c0-a6ef-8419a9f93a2e: [1,False,UK Mail Next Day - XXL]
result: -1
a: c6efa935-448a-46f5-939e-83672b195102: [1,False,RM USJFKA - BA]
b: b9ca8064-2f1e-400a-8b07-06819d36eaa8: [1,False,UK Mail Next Day - XXL]
result: -1
a: c6efa935-448a-46f5-939e-83672b195102: [1,False,RM USJFKA - BA]
b: 426ae142-d93e-4217-82a5-16bedb0ba6b9: [1,False,UK Mail Next Day - XXL]
result: -1
a: c6efa935-448a-46f5-939e-83672b195102: [1,False,RM USJFKA - BA]
b: f7b742f7-48be-4c1a-a041-3a09a0491642: [1,False,RM VANCOUVER - BA]
result: -1
a: c6efa935-448a-46f5-939e-83672b195102: [1,False,RM USJFKA - BA]
b: e0f6b653-4633-4c0a-9282-7386838f3065: [1,False,RM VANCOUVER - BA]
result: -1
a: c6efa935-448a-46f5-939e-83672b195102: [1,False,RM USJFKA - BA]
b: be4f788f-2720-4c2b-a7c7-e485f9749593: [1,False,RM VANCOUVER - BA]
result: -1
a: c6efa935-448a-46f5-939e-83672b195102: [1,False,RM USJFKA - BA]
b: ad0745c9-4442-48f3-8e0c-3725323dbb28: [1,False,RM VANCOUVER - BA]
result: -1
a: c6efa935-448a-46f5-939e-83672b195102: [1,False,RM USJFKA - BA]
b: 85c490a8-0983-42b1-9e9c-c9ff50cc1fb9: [1,False,RM VANCOUVER - BA]
result: -1
a: c6efa935-448a-46f5-939e-83672b195102: [1,False,RM USJFKA - BA]
b: 731fa41e-864e-42b0-8624-5554f22c1ac4: [1,False,RM VANCOUVER - BA]
result: -1
a: c6efa935-448a-46f5-939e-83672b195102: [1,False,RM USJFKA - BA]
b: 49518b34-7fc5-452d-8e85-dfc57362ea95: [1,False,RM VANCOUVER - BA]
result: -1
a: c6efa935-448a-46f5-939e-83672b195102: [1,False,RM USJFKA - BA]
b: 4377f241-5b84-4e63-8fa6-19f0f0153474: [1,False,RM VANCOUVER - BA]
result: -1
a: c6efa935-448a-46f5-939e-83672b195102: [1,False,RM USJFKA - BA]
b: 149419cf-f132-46e8-92be-784bcd93da43: [1,False,RM VANCOUVER - BA]
result: -1
a: c6efa935-448a-46f5-939e-83672b195102: [1,False,RM USJFKA - BA]
b: 0f6fd091-ee3d-4773-a993-55735aef8119: [1,False,RM VANCOUVER - BA]
result: -1
a: c6efa935-448a-46f5-939e-83672b195102: [1,False,RM USJFKA - BA]
b: dfe05612-1a06-4105-82dc-3bf8b750c5b5: [1,False,RM USSFOA - BA]
result: -1
a: c6efa935-448a-46f5-939e-83672b195102: [1,False,RM USJFKA - BA]
b: 3239d4f9-0be1-4d26-a0c4-5e7dc6b2c076: [1,False,RM USSFOA - BA]
result: -1
a: c6efa935-448a-46f5-939e-83672b195102: [1,False,RM USJFKA - BA]
b: 2b1a498f-f31b-4775-9d0c-a49c98637865: [1,False,RM USSFOA - BA]
result: -1
a: c6efa935-448a-46f5-939e-83672b195102: [1,False,RM USJFKA - BA]
b: 0f99c3dc-df5c-4c1d-b710-9f9a9078da2c: [1,False,RM USSFOA - BA]
result: -1
a: c6efa935-448a-46f5-939e-83672b195102: [1,False,RM USJFKA - BA]
b: c57f2005-a12e-43de-aef4-c950bfa6c624: [1,False,RM USORDA - BA]
result: -1
a: c6efa935-448a-46f5-939e-83672b195102: [1,False,RM USJFKA - BA]
b: a0414290-a73d-4a26-8123-a6f4496660ab: [1,False,RM USORDA - BA]
result: -1
a: c6efa935-448a-46f5-939e-83672b195102: [1,False,RM USJFKA - BA]
b: 92fdfff9-7343-4043-95d0-1be8d3e00774: [1,False,RM USORDA - BA]
result: -1
a: c6efa935-448a-46f5-939e-83672b195102: [1,False,RM USJFKA - BA]
b: 6c52763e-badc-4d7e-9165-cae76d4d9d74: [1,False,RM USORDA - BA]
result: -1
a: c6efa935-448a-46f5-939e-83672b195102: [1,False,RM USJFKA - BA]
b: 6179bb17-feef-44cc-8ec2-f9e640396847: [1,False,RM USORDA - BA]
result: -1
a: c6efa935-448a-46f5-939e-83672b195102: [1,False,RM USJFKA - BA]
b: 4ec27f3a-1305-4897-a4cf-e8324944d25a: [1,False,RM USORDA - BA]
result: -1
a: c6efa935-448a-46f5-939e-83672b195102: [1,False,RM USJFKA - BA]
b: 44c3277b-8c4c-47c9-b987-ed80b1c83380: [1,False,RM USORDA - BA]
result: -1
a: c6efa935-448a-46f5-939e-83672b195102: [1,False,RM USJFKA - BA]
b: 208d0871-daf7-4169-b860-9bb516a995c0: [1,False,RM USORDA - BA]
result: -1
a: c6efa935-448a-46f5-939e-83672b195102: [1,False,RM USJFKA - BA]
b: 1965ba6b-0156-4749-a1e3-4ed7a419d81c: [1,False,RM USORDA - BA]
result: -1
a: c6efa935-448a-46f5-939e-83672b195102: [1,False,RM USJFKA - BA]
b: 0e4edb3b-5acb-4227-9b76-a91f297cc7f2: [1,False,RM USORDA - BA]
result: -1
a: c6efa935-448a-46f5-939e-83672b195102: [1,False,RM USJFKA - BA]
b: 081860df-3349-4f17-bc87-14baab2ee3d2: [1,False,RM USORDA - BA]
result: -1
a: c6efa935-448a-46f5-939e-83672b195102: [1,False,RM USJFKA - BA]
b: fbc883e4-e960-4769-85a8-0de06ea26069: [1,False,RM USLAXA - BA]
result: -1
a: c6efa935-448a-46f5-939e-83672b195102: [1,False,RM USJFKA - BA]
b: f3e11631-dfc4-440d-96dc-f04fb7810127: [1,False,RM USLAXA - BA]
result: -1
a: c6efa935-448a-46f5-939e-83672b195102: [1,False,RM USJFKA - BA]
b: 9eceff7d-816c-4908-9776-d1bea99a5cdc: [1,False,RM USLAXA - BA]
result: -1
a: c6efa935-448a-46f5-939e-83672b195102: [1,False,RM USJFKA - BA]
b: 856a3a22-860c-4b4a-8a78-530006460ba4: [1,False,RM USLAXA - BA]
result: -1
a: c6efa935-448a-46f5-939e-83672b195102: [1,False,RM USJFKA - BA]
b: 767ce763-3c60-42b7-96be-8c0e407f5500: [1,False,RM USLAXA - BA]
result: -1
a: c6efa935-448a-46f5-939e-83672b195102: [1,False,RM USJFKA - BA]
b: 5cea72ec-d370-4d6a-ab1b-425bbe84d6c9: [1,False,RM USLAXA - BA]
result: -1
a: c6efa935-448a-46f5-939e-83672b195102: [1,False,RM USJFKA - BA]
b: 49a8751a-41d9-4ccd-aace-29265a8eb7db: [1,False,RM USLAXA - BA]
result: -1
a: c6efa935-448a-46f5-939e-83672b195102: [1,False,RM USJFKA - BA]
b: 1b814e9c-2706-4aa4-a105-2cdbc5e670fd: [1,False,RM USLAXA - BA]
result: -1
a: c6efa935-448a-46f5-939e-83672b195102: [1,False,RM USJFKA - BA]
b: 0ff80f3b-a91e-4357-ba86-b339d9a7488c: [1,False,RM USLAXA - BA]
result: -1
a: c6efa935-448a-46f5-939e-83672b195102: [1,False,RM USJFKA - BA]
b: eaae3178-be80-420b-858d-031a7af23f26: [1,False,RM USJFKA - BA]
result: -1
a: c6efa935-448a-46f5-939e-83672b195102: [1,False,RM USJFKA - BA]
b: e870ebf5-af6e-4764-a89c-2deab5e9728c: [1,False,RM USJFKA - BA]
result: -1
a: c6efa935-448a-46f5-939e-83672b195102: [1,False,RM USJFKA - BA]
b: 8eb9bb08-4afd-457b-ad96-f0e93c1aebf1: [4,False,YODEL LOUNGER XXXL]
result: -1
a: c6efa935-448a-46f5-939e-83672b195102: [1,False,RM USJFKA - BA]
b: c6629e65-823e-4048-9877-8bbf1a3e5a77: [1,False,RM USJFKA - BA]
result: 1
a: e870ebf5-af6e-4764-a89c-2deab5e9728c: [1,False,RM USJFKA - BA]
b: b9ca8064-2f1e-400a-8b07-06819d36eaa8: [1,False,UK Mail Next Day - XXL]
result: -1
a: e870ebf5-af6e-4764-a89c-2deab5e9728c: [1,False,RM USJFKA - BA]
b: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
result: -1
a: b9ca8064-2f1e-400a-8b07-06819d36eaa8: [1,False,UK Mail Next Day - XXL]
b: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
result: -1
a: eaae3178-be80-420b-858d-031a7af23f26: [1,False,RM USJFKA - BA]
b: b9ca8064-2f1e-400a-8b07-06819d36eaa8: [1,False,UK Mail Next Day - XXL]
result: -1
a: 0ff80f3b-a91e-4357-ba86-b339d9a7488c: [1,False,RM USLAXA - BA]
b: b9ca8064-2f1e-400a-8b07-06819d36eaa8: [1,False,UK Mail Next Day - XXL]
result: -1
a: 1b814e9c-2706-4aa4-a105-2cdbc5e670fd: [1,False,RM USLAXA - BA]
b: b9ca8064-2f1e-400a-8b07-06819d36eaa8: [1,False,UK Mail Next Day - XXL]
result: -1
a: 49a8751a-41d9-4ccd-aace-29265a8eb7db: [1,False,RM USLAXA - BA]
b: b9ca8064-2f1e-400a-8b07-06819d36eaa8: [1,False,UK Mail Next Day - XXL]
result: -1
a: 5cea72ec-d370-4d6a-ab1b-425bbe84d6c9: [1,False,RM USLAXA - BA]
b: b9ca8064-2f1e-400a-8b07-06819d36eaa8: [1,False,UK Mail Next Day - XXL]
result: -1
a: 767ce763-3c60-42b7-96be-8c0e407f5500: [1,False,RM USLAXA - BA]
b: b9ca8064-2f1e-400a-8b07-06819d36eaa8: [1,False,UK Mail Next Day - XXL]
result: -1
a: 856a3a22-860c-4b4a-8a78-530006460ba4: [1,False,RM USLAXA - BA]
b: b9ca8064-2f1e-400a-8b07-06819d36eaa8: [1,False,UK Mail Next Day - XXL]
result: -1
a: 9eceff7d-816c-4908-9776-d1bea99a5cdc: [1,False,RM USLAXA - BA]
b: b9ca8064-2f1e-400a-8b07-06819d36eaa8: [1,False,UK Mail Next Day - XXL]
result: -1
a: f3e11631-dfc4-440d-96dc-f04fb7810127: [1,False,RM USLAXA - BA]
b: b9ca8064-2f1e-400a-8b07-06819d36eaa8: [1,False,UK Mail Next Day - XXL]
result: -1
a: fbc883e4-e960-4769-85a8-0de06ea26069: [1,False,RM USLAXA - BA]
b: b9ca8064-2f1e-400a-8b07-06819d36eaa8: [1,False,UK Mail Next Day - XXL]
result: -1
a: 081860df-3349-4f17-bc87-14baab2ee3d2: [1,False,RM USORDA - BA]
b: b9ca8064-2f1e-400a-8b07-06819d36eaa8: [1,False,UK Mail Next Day - XXL]
result: -1
a: 0e4edb3b-5acb-4227-9b76-a91f297cc7f2: [1,False,RM USORDA - BA]
b: b9ca8064-2f1e-400a-8b07-06819d36eaa8: [1,False,UK Mail Next Day - XXL]
result: -1
a: 1965ba6b-0156-4749-a1e3-4ed7a419d81c: [1,False,RM USORDA - BA]
b: b9ca8064-2f1e-400a-8b07-06819d36eaa8: [1,False,UK Mail Next Day - XXL]
result: -1
a: 208d0871-daf7-4169-b860-9bb516a995c0: [1,False,RM USORDA - BA]
b: b9ca8064-2f1e-400a-8b07-06819d36eaa8: [1,False,UK Mail Next Day - XXL]
result: -1
a: 44c3277b-8c4c-47c9-b987-ed80b1c83380: [1,False,RM USORDA - BA]
b: b9ca8064-2f1e-400a-8b07-06819d36eaa8: [1,False,UK Mail Next Day - XXL]
result: -1
a: 4ec27f3a-1305-4897-a4cf-e8324944d25a: [1,False,RM USORDA - BA]
b: b9ca8064-2f1e-400a-8b07-06819d36eaa8: [1,False,UK Mail Next Day - XXL]
result: -1
a: 6179bb17-feef-44cc-8ec2-f9e640396847: [1,False,RM USORDA - BA]
b: b9ca8064-2f1e-400a-8b07-06819d36eaa8: [1,False,UK Mail Next Day - XXL]
result: -1
a: 6c52763e-badc-4d7e-9165-cae76d4d9d74: [1,False,RM USORDA - BA]
b: b9ca8064-2f1e-400a-8b07-06819d36eaa8: [1,False,UK Mail Next Day - XXL]
result: -1
a: 92fdfff9-7343-4043-95d0-1be8d3e00774: [1,False,RM USORDA - BA]
b: b9ca8064-2f1e-400a-8b07-06819d36eaa8: [1,False,UK Mail Next Day - XXL]
result: -1
a: a0414290-a73d-4a26-8123-a6f4496660ab: [1,False,RM USORDA - BA]
b: b9ca8064-2f1e-400a-8b07-06819d36eaa8: [1,False,UK Mail Next Day - XXL]
result: -1
a: c57f2005-a12e-43de-aef4-c950bfa6c624: [1,False,RM USORDA - BA]
b: b9ca8064-2f1e-400a-8b07-06819d36eaa8: [1,False,UK Mail Next Day - XXL]
result: -1
a: 0f99c3dc-df5c-4c1d-b710-9f9a9078da2c: [1,False,RM USSFOA - BA]
b: b9ca8064-2f1e-400a-8b07-06819d36eaa8: [1,False,UK Mail Next Day - XXL]
result: -1
a: 2b1a498f-f31b-4775-9d0c-a49c98637865: [1,False,RM USSFOA - BA]
b: b9ca8064-2f1e-400a-8b07-06819d36eaa8: [1,False,UK Mail Next Day - XXL]
result: -1
a: 3239d4f9-0be1-4d26-a0c4-5e7dc6b2c076: [1,False,RM USSFOA - BA]
b: b9ca8064-2f1e-400a-8b07-06819d36eaa8: [1,False,UK Mail Next Day - XXL]
result: -1
a: dfe05612-1a06-4105-82dc-3bf8b750c5b5: [1,False,RM USSFOA - BA]
b: b9ca8064-2f1e-400a-8b07-06819d36eaa8: [1,False,UK Mail Next Day - XXL]
result: -1
a: 0f6fd091-ee3d-4773-a993-55735aef8119: [1,False,RM VANCOUVER - BA]
b: b9ca8064-2f1e-400a-8b07-06819d36eaa8: [1,False,UK Mail Next Day - XXL]
result: -1
a: 149419cf-f132-46e8-92be-784bcd93da43: [1,False,RM VANCOUVER - BA]
b: b9ca8064-2f1e-400a-8b07-06819d36eaa8: [1,False,UK Mail Next Day - XXL]
result: -1
a: 4377f241-5b84-4e63-8fa6-19f0f0153474: [1,False,RM VANCOUVER - BA]
b: b9ca8064-2f1e-400a-8b07-06819d36eaa8: [1,False,UK Mail Next Day - XXL]
result: -1
a: 49518b34-7fc5-452d-8e85-dfc57362ea95: [1,False,RM VANCOUVER - BA]
b: b9ca8064-2f1e-400a-8b07-06819d36eaa8: [1,False,UK Mail Next Day - XXL]
result: -1
a: 731fa41e-864e-42b0-8624-5554f22c1ac4: [1,False,RM VANCOUVER - BA]
b: b9ca8064-2f1e-400a-8b07-06819d36eaa8: [1,False,UK Mail Next Day - XXL]
result: -1
a: 85c490a8-0983-42b1-9e9c-c9ff50cc1fb9: [1,False,RM VANCOUVER - BA]
b: b9ca8064-2f1e-400a-8b07-06819d36eaa8: [1,False,UK Mail Next Day - XXL]
result: -1
a: ad0745c9-4442-48f3-8e0c-3725323dbb28: [1,False,RM VANCOUVER - BA]
b: b9ca8064-2f1e-400a-8b07-06819d36eaa8: [1,False,UK Mail Next Day - XXL]
result: -1
a: be4f788f-2720-4c2b-a7c7-e485f9749593: [1,False,RM VANCOUVER - BA]
b: b9ca8064-2f1e-400a-8b07-06819d36eaa8: [1,False,UK Mail Next Day - XXL]
result: -1
a: e0f6b653-4633-4c0a-9282-7386838f3065: [1,False,RM VANCOUVER - BA]
b: b9ca8064-2f1e-400a-8b07-06819d36eaa8: [1,False,UK Mail Next Day - XXL]
result: -1
a: f7b742f7-48be-4c1a-a041-3a09a0491642: [1,False,RM VANCOUVER - BA]
b: b9ca8064-2f1e-400a-8b07-06819d36eaa8: [1,False,UK Mail Next Day - XXL]
result: -1
a: 426ae142-d93e-4217-82a5-16bedb0ba6b9: [1,False,UK Mail Next Day - XXL]
b: b9ca8064-2f1e-400a-8b07-06819d36eaa8: [1,False,UK Mail Next Day - XXL]
result: -1
a: 8eb9bb08-4afd-457b-ad96-f0e93c1aebf1: [4,False,YODEL LOUNGER XXXL]
b: b9ca8064-2f1e-400a-8b07-06819d36eaa8: [1,False,UK Mail Next Day - XXL]
result: 1
a: b9ca8064-2f1e-400a-8b07-06819d36eaa8: [1,False,UK Mail Next Day - XXL]
b: c3850c89-d305-4a99-9e7f-1917400795a0: [4,False,XXL UK MAIN]
result: -1
a: b9ca8064-2f1e-400a-8b07-06819d36eaa8: [1,False,UK Mail Next Day - XXL]
b: 22879b7b-f3f9-45c9-88ad-41c0bfca93df: [4,False,XXL UK MAIN]
result: -1
a: b9ca8064-2f1e-400a-8b07-06819d36eaa8: [1,False,UK Mail Next Day - XXL]
b: b2a18851-9f95-4266-a669-fd3220738c35: [4,False,UK Mail Next Day - BA]
result: -1
a: b9ca8064-2f1e-400a-8b07-06819d36eaa8: [1,False,UK Mail Next Day - XXL]
b: f5edc9f3-0747-46b3-a623-92e9c58dd968: [4,False,RM MONTREAL - BA]
result: -1
a: b9ca8064-2f1e-400a-8b07-06819d36eaa8: [1,False,UK Mail Next Day - XXL]
b: 68abf144-2606-48e0-b84a-32018f937163: [4,False,RM ITALY - BA]
result: -1
a: b9ca8064-2f1e-400a-8b07-06819d36eaa8: [1,False,UK Mail Next Day - XXL]
b: 7a2eb7db-1dac-4e78-9e65-6b854913dbec: [4,False,RM GERMANY - BA]
result: -1
a: b9ca8064-2f1e-400a-8b07-06819d36eaa8: [1,False,UK Mail Next Day - XXL]
b: d1aa9fda-f0fa-44f8-a976-e58d75b65010: [4,False,RM FRANCE - BA]
result: -1
a: b9ca8064-2f1e-400a-8b07-06819d36eaa8: [1,False,UK Mail Next Day - XXL]
b: 83a5d510-b129-4a44-813f-fc42c1f05691: [4,False,RM FRANCE - BA]
result: -1
a: b9ca8064-2f1e-400a-8b07-06819d36eaa8: [1,False,UK Mail Next Day - XXL]
b: 3dbc8a0a-1fd2-4345-b503-7207343c3932: [4,False,DPD Next Day 12:00 - BA]
result: -1
a: b9ca8064-2f1e-400a-8b07-06819d36eaa8: [1,False,UK Mail Next Day - XXL]
b: fae33594-a087-4663-a81c-965324f60c82: [4,False,DPD Classic Expresspak - BA]
result: -1
a: b9ca8064-2f1e-400a-8b07-06819d36eaa8: [1,False,UK Mail Next Day - XXL]
b: 56b949a4-50cc-43dc-8628-ea5e223cecfe: [4,False,DPD Classic - BA]
result: -1
a: b9ca8064-2f1e-400a-8b07-06819d36eaa8: [1,False,UK Mail Next Day - XXL]
b: fce2463b-96dc-4201-86ac-643fa0928d88: [4,False,48T - PACKET - BA]
result: -1
a: b9ca8064-2f1e-400a-8b07-06819d36eaa8: [1,False,UK Mail Next Day - XXL]
b: f1774705-d517-4e9a-a500-75dcd3688ac5: [4,False,48T - PACKET - BA]
result: -1
a: b9ca8064-2f1e-400a-8b07-06819d36eaa8: [1,False,UK Mail Next Day - XXL]
b: cdb566da-4605-4145-8a76-c20931b27665: [4,False,UK Mail Next Day - BA]
result: -1
a: b9ca8064-2f1e-400a-8b07-06819d36eaa8: [1,False,UK Mail Next Day - XXL]
b: e6585a19-9220-484b-9389-27f6d7418629: [4,False,48T - PACKET - BA]
result: -1
a: b9ca8064-2f1e-400a-8b07-06819d36eaa8: [1,False,UK Mail Next Day - XXL]
b: c3a23121-879f-464f-836d-a4bf28a77a90: [4,False,48T - PACKET - BA]
result: -1
a: b9ca8064-2f1e-400a-8b07-06819d36eaa8: [1,False,UK Mail Next Day - XXL]
b: a17bc221-846a-4615-80e1-389d7f2f1976: [4,False,48T - PACKET - BA]
result: -1
a: b9ca8064-2f1e-400a-8b07-06819d36eaa8: [1,False,UK Mail Next Day - XXL]
b: 71b6dba8-e2cb-4e34-9677-e877e2dff31c: [4,False,48T - PACKET - BA]
result: -1
a: b9ca8064-2f1e-400a-8b07-06819d36eaa8: [1,False,UK Mail Next Day - XXL]
b: 608bf888-4b13-43a1-9339-293ca14af64b: [4,False,48T - PACKET - BA]
result: -1
a: b9ca8064-2f1e-400a-8b07-06819d36eaa8: [1,False,UK Mail Next Day - XXL]
b: 5ea587ec-22bd-4eb6-a357-aa4117a30a6f: [4,False,48T - PACKET - BA]
result: -1
a: b9ca8064-2f1e-400a-8b07-06819d36eaa8: [1,False,UK Mail Next Day - XXL]
b: 38f2068c-e6f0-44de-829c-dd08d320d8d4: [4,False,48T - PACKET - BA]
result: -1
a: b9ca8064-2f1e-400a-8b07-06819d36eaa8: [1,False,UK Mail Next Day - XXL]
b: 2c1cc50f-25fa-43a9-816b-b0eb74cc2ad4: [4,False,48T - PACKET - BA]
result: -1
a: b9ca8064-2f1e-400a-8b07-06819d36eaa8: [1,False,UK Mail Next Day - XXL]
b: 1d1677f1-debd-4297-bf33-013960ec6f6a: [4,False,48T - PACKET - BA]
result: -1
a: b9ca8064-2f1e-400a-8b07-06819d36eaa8: [1,False,UK Mail Next Day - XXL]
b: 0b3594f0-c632-4bf9-9592-bd777ce7605d: [4,False,48T - PACKET - BA]
result: -1
a: b9ca8064-2f1e-400a-8b07-06819d36eaa8: [1,False,UK Mail Next Day - XXL]
b: 3bc84e93-bbe1-4ba2-99c2-cd70dd385833: [4,False,3H - UK MAIN]
result: -1
a: b9ca8064-2f1e-400a-8b07-06819d36eaa8: [1,False,UK Mail Next Day - XXL]
b: fcf1f831-dee2-47a3-b2af-ee1e9678c733: [4,False,1H - UK MAIN]
result: -1
a: b9ca8064-2f1e-400a-8b07-06819d36eaa8: [1,False,UK Mail Next Day - XXL]
b: 81c0362b-3c4e-43ce-a3f6-5ac56c3032d7: [4,False,1H - UK MAIN]
result: -1
a: b9ca8064-2f1e-400a-8b07-06819d36eaa8: [1,False,UK Mail Next Day - XXL]
b: 7f942cf0-4815-4702-b0ad-b74794c7c100: [4,False,1H - UK MAIN]
result: -1
a: b9ca8064-2f1e-400a-8b07-06819d36eaa8: [1,False,UK Mail Next Day - XXL]
b: 5aa0e132-0345-4969-898e-6511a1175998: [4,False,1H - UK MAIN]
result: -1
a: b9ca8064-2f1e-400a-8b07-06819d36eaa8: [1,False,UK Mail Next Day - XXL]
b: 22c88bf4-e0f6-4ea0-8c70-aaaa0fd7cfb9: [4,False,1H - UK MAIN]
result: -1
a: b9ca8064-2f1e-400a-8b07-06819d36eaa8: [1,False,UK Mail Next Day - XXL]
b: b79958b6-e7ce-43b5-9d7e-b7d4e42fab92: [4,False,1H - BT]
result: -1
a: b9ca8064-2f1e-400a-8b07-06819d36eaa8: [1,False,UK Mail Next Day - XXL]
b: 7fa22520-c5fd-43f8-be05-c51d2f3edf21: [4,False,1H - BT]
result: -1
a: b9ca8064-2f1e-400a-8b07-06819d36eaa8: [1,False,UK Mail Next Day - XXL]
b: f563f11f-70e0-4620-bfaf-a57117c6f862: [1,False,YODEL LOUNGER XXXL]
result: -1
a: b9ca8064-2f1e-400a-8b07-06819d36eaa8: [1,False,UK Mail Next Day - XXL]
b: 16ba9df3-5f17-4e32-bcff-f2128bc74a64: [1,False,YODEL LOUNGER XXXL]
result: -1
a: b9ca8064-2f1e-400a-8b07-06819d36eaa8: [1,False,UK Mail Next Day - XXL]
b: a8297186-b743-4f44-abd4-99aa351f7b03: [1,False,XXL ISLE]
result: -1
a: b9ca8064-2f1e-400a-8b07-06819d36eaa8: [1,False,UK Mail Next Day - XXL]
b: e6879e85-beb2-41c0-a6ef-8419a9f93a2e: [1,False,UK Mail Next Day - XXL]
result: -1
a: b9ca8064-2f1e-400a-8b07-06819d36eaa8: [1,False,UK Mail Next Day - XXL]
b: 8eb9bb08-4afd-457b-ad96-f0e93c1aebf1: [4,False,YODEL LOUNGER XXXL]
result: -1
a: b9ca8064-2f1e-400a-8b07-06819d36eaa8: [1,False,UK Mail Next Day - XXL]
b: 426ae142-d93e-4217-82a5-16bedb0ba6b9: [1,False,UK Mail Next Day - XXL]
result: 1
a: e6879e85-beb2-41c0-a6ef-8419a9f93a2e: [1,False,UK Mail Next Day - XXL]
b: 71b6dba8-e2cb-4e34-9677-e877e2dff31c: [4,False,48T - PACKET - BA]
result: -1
a: e6879e85-beb2-41c0-a6ef-8419a9f93a2e: [1,False,UK Mail Next Day - XXL]
b: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
result: -1
a: 71b6dba8-e2cb-4e34-9677-e877e2dff31c: [4,False,48T - PACKET - BA]
b: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
result: 1
a: a8297186-b743-4f44-abd4-99aa351f7b03: [1,False,XXL ISLE]
b: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
result: -1
a: 16ba9df3-5f17-4e32-bcff-f2128bc74a64: [1,False,YODEL LOUNGER XXXL]
b: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
result: -1
a: f563f11f-70e0-4620-bfaf-a57117c6f862: [1,False,YODEL LOUNGER XXXL]
b: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
result: -1
a: 7fa22520-c5fd-43f8-be05-c51d2f3edf21: [4,False,1H - BT]
b: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
result: 1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: c3850c89-d305-4a99-9e7f-1917400795a0: [4,False,XXL UK MAIN]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 22879b7b-f3f9-45c9-88ad-41c0bfca93df: [4,False,XXL UK MAIN]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: b2a18851-9f95-4266-a669-fd3220738c35: [4,False,UK Mail Next Day - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: f5edc9f3-0747-46b3-a623-92e9c58dd968: [4,False,RM MONTREAL - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 68abf144-2606-48e0-b84a-32018f937163: [4,False,RM ITALY - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 7a2eb7db-1dac-4e78-9e65-6b854913dbec: [4,False,RM GERMANY - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: d1aa9fda-f0fa-44f8-a976-e58d75b65010: [4,False,RM FRANCE - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 83a5d510-b129-4a44-813f-fc42c1f05691: [4,False,RM FRANCE - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 3dbc8a0a-1fd2-4345-b503-7207343c3932: [4,False,DPD Next Day 12:00 - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: fae33594-a087-4663-a81c-965324f60c82: [4,False,DPD Classic Expresspak - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 56b949a4-50cc-43dc-8628-ea5e223cecfe: [4,False,DPD Classic - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: fce2463b-96dc-4201-86ac-643fa0928d88: [4,False,48T - PACKET - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: f1774705-d517-4e9a-a500-75dcd3688ac5: [4,False,48T - PACKET - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: cdb566da-4605-4145-8a76-c20931b27665: [4,False,UK Mail Next Day - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: e6585a19-9220-484b-9389-27f6d7418629: [4,False,48T - PACKET - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: c3a23121-879f-464f-836d-a4bf28a77a90: [4,False,48T - PACKET - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: a17bc221-846a-4615-80e1-389d7f2f1976: [4,False,48T - PACKET - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 8eb9bb08-4afd-457b-ad96-f0e93c1aebf1: [4,False,YODEL LOUNGER XXXL]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 608bf888-4b13-43a1-9339-293ca14af64b: [4,False,48T - PACKET - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 5ea587ec-22bd-4eb6-a357-aa4117a30a6f: [4,False,48T - PACKET - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 38f2068c-e6f0-44de-829c-dd08d320d8d4: [4,False,48T - PACKET - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 2c1cc50f-25fa-43a9-816b-b0eb74cc2ad4: [4,False,48T - PACKET - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 1d1677f1-debd-4297-bf33-013960ec6f6a: [4,False,48T - PACKET - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 0b3594f0-c632-4bf9-9592-bd777ce7605d: [4,False,48T - PACKET - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 3bc84e93-bbe1-4ba2-99c2-cd70dd385833: [4,False,3H - UK MAIN]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: fcf1f831-dee2-47a3-b2af-ee1e9678c733: [4,False,1H - UK MAIN]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 81c0362b-3c4e-43ce-a3f6-5ac56c3032d7: [4,False,1H - UK MAIN]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 7f942cf0-4815-4702-b0ad-b74794c7c100: [4,False,1H - UK MAIN]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 5aa0e132-0345-4969-898e-6511a1175998: [4,False,1H - UK MAIN]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 22c88bf4-e0f6-4ea0-8c70-aaaa0fd7cfb9: [4,False,1H - UK MAIN]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: b79958b6-e7ce-43b5-9d7e-b7d4e42fab92: [4,False,1H - BT]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 7fa22520-c5fd-43f8-be05-c51d2f3edf21: [4,False,1H - BT]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: f563f11f-70e0-4620-bfaf-a57117c6f862: [1,False,YODEL LOUNGER XXXL]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 16ba9df3-5f17-4e32-bcff-f2128bc74a64: [1,False,YODEL LOUNGER XXXL]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: a8297186-b743-4f44-abd4-99aa351f7b03: [1,False,XXL ISLE]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: e6879e85-beb2-41c0-a6ef-8419a9f93a2e: [1,False,UK Mail Next Day - XXL]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: b9ca8064-2f1e-400a-8b07-06819d36eaa8: [1,False,UK Mail Next Day - XXL]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 426ae142-d93e-4217-82a5-16bedb0ba6b9: [1,False,UK Mail Next Day - XXL]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: f7b742f7-48be-4c1a-a041-3a09a0491642: [1,False,RM VANCOUVER - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: e0f6b653-4633-4c0a-9282-7386838f3065: [1,False,RM VANCOUVER - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: be4f788f-2720-4c2b-a7c7-e485f9749593: [1,False,RM VANCOUVER - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: ad0745c9-4442-48f3-8e0c-3725323dbb28: [1,False,RM VANCOUVER - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 85c490a8-0983-42b1-9e9c-c9ff50cc1fb9: [1,False,RM VANCOUVER - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 731fa41e-864e-42b0-8624-5554f22c1ac4: [1,False,RM VANCOUVER - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 49518b34-7fc5-452d-8e85-dfc57362ea95: [1,False,RM VANCOUVER - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 4377f241-5b84-4e63-8fa6-19f0f0153474: [1,False,RM VANCOUVER - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 149419cf-f132-46e8-92be-784bcd93da43: [1,False,RM VANCOUVER - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 0f6fd091-ee3d-4773-a993-55735aef8119: [1,False,RM VANCOUVER - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: dfe05612-1a06-4105-82dc-3bf8b750c5b5: [1,False,RM USSFOA - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 3239d4f9-0be1-4d26-a0c4-5e7dc6b2c076: [1,False,RM USSFOA - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 2b1a498f-f31b-4775-9d0c-a49c98637865: [1,False,RM USSFOA - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 0f99c3dc-df5c-4c1d-b710-9f9a9078da2c: [1,False,RM USSFOA - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: c57f2005-a12e-43de-aef4-c950bfa6c624: [1,False,RM USORDA - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: a0414290-a73d-4a26-8123-a6f4496660ab: [1,False,RM USORDA - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 92fdfff9-7343-4043-95d0-1be8d3e00774: [1,False,RM USORDA - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 6c52763e-badc-4d7e-9165-cae76d4d9d74: [1,False,RM USORDA - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 6179bb17-feef-44cc-8ec2-f9e640396847: [1,False,RM USORDA - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 4ec27f3a-1305-4897-a4cf-e8324944d25a: [1,False,RM USORDA - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 44c3277b-8c4c-47c9-b987-ed80b1c83380: [1,False,RM USORDA - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 208d0871-daf7-4169-b860-9bb516a995c0: [1,False,RM USORDA - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 1965ba6b-0156-4749-a1e3-4ed7a419d81c: [1,False,RM USORDA - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 0e4edb3b-5acb-4227-9b76-a91f297cc7f2: [1,False,RM USORDA - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 081860df-3349-4f17-bc87-14baab2ee3d2: [1,False,RM USORDA - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: fbc883e4-e960-4769-85a8-0de06ea26069: [1,False,RM USLAXA - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: f3e11631-dfc4-440d-96dc-f04fb7810127: [1,False,RM USLAXA - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 9eceff7d-816c-4908-9776-d1bea99a5cdc: [1,False,RM USLAXA - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 856a3a22-860c-4b4a-8a78-530006460ba4: [1,False,RM USLAXA - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 767ce763-3c60-42b7-96be-8c0e407f5500: [1,False,RM USLAXA - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 5cea72ec-d370-4d6a-ab1b-425bbe84d6c9: [1,False,RM USLAXA - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 49a8751a-41d9-4ccd-aace-29265a8eb7db: [1,False,RM USLAXA - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 1b814e9c-2706-4aa4-a105-2cdbc5e670fd: [1,False,RM USLAXA - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 0ff80f3b-a91e-4357-ba86-b339d9a7488c: [1,False,RM USLAXA - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: eaae3178-be80-420b-858d-031a7af23f26: [1,False,RM USJFKA - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: e870ebf5-af6e-4764-a89c-2deab5e9728c: [1,False,RM USJFKA - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: c6efa935-448a-46f5-939e-83672b195102: [1,False,RM USJFKA - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: c6629e65-823e-4048-9877-8bbf1a3e5a77: [1,False,RM USJFKA - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: c548b03d-45ca-4b83-ac8f-205eef8be17c: [1,False,RM USJFKA - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: bfbd81e6-100e-441a-81ea-590a81d3bc3f: [1,False,RM USJFKA - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: a45a07b5-ba2e-4a09-b3d4-5c897c7a6d7a: [1,False,RM USJFKA - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: a2a92676-0f19-4f39-89e7-92dbb4c1de48: [1,False,RM USJFKA - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 8eb695d7-5773-4c63-aec2-76f874fb4076: [1,False,RM USJFKA - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 8b7f596e-f203-4a77-bdb8-711f462c117d: [1,False,RM USJFKA - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 83c0c531-ca32-4cec-802d-2b7ad9fecd3a: [1,False,RM USJFKA - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 764df177-0d69-47e4-9aa1-c8ba495ab412: [1,False,RM USJFKA - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 5a3d2010-0816-4613-9b9e-63afd94312b2: [1,False,RM USJFKA - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 569b232f-fe59-455c-a38b-6e80b9e1cd2b: [1,False,RM USJFKA - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 4702eb62-a473-4bc2-adf7-effb2619480f: [1,False,RM USJFKA - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 2e855f49-0d8c-42a3-aa53-05edfc72bb81: [1,False,RM USJFKA - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 22a236e1-3da8-44f9-b853-f508913641b7: [1,False,RM USJFKA - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 17ddbe7b-0f83-40d8-916d-9ce0beb4ab0b: [1,False,RM USJFKA - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: f9bb4176-4033-4faf-8681-269e8375d79a: [1,False,RM TORONTO-A - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: f0d94469-7c3f-4780-89f7-17bf97b8af88: [1,False,RM TORONTO-A - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: e1c69b5a-2711-4584-bd9a-555395804082: [1,False,RM TORONTO-A - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: e0b9405c-a4b3-43a5-87d1-f98c878c4ac3: [1,False,RM TORONTO-A - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: d9b1fea0-a484-4b02-b46b-99b7c95ac8a5: [1,False,RM TORONTO-A - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: d614a12b-87a7-46ce-93c7-afd837d8e084: [1,False,RM TORONTO-A - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: bc4ac6d1-bd45-4982-8067-00de502afe55: [1,False,RM TORONTO-A - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: bae0caa1-93eb-4be4-a62c-dfdf4a2ff419: [1,False,RM TORONTO-A - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: a318a335-5fba-4df5-adcf-bb2cb3bbefbc: [1,False,RM TORONTO-A - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 8c2431c9-d770-4ee0-9ebb-e5dc8683974b: [1,False,RM TORONTO-A - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 6c10ff57-21d6-4dfb-b397-5a4515284bc5: [1,False,RM TORONTO-A - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: dcd165ec-01f2-4085-9f9b-542ed7725087: [1,False,RM SYDNEY - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: cb5d78e2-bdc6-43ae-b016-7e55ec724c31: [1,False,RM SYDNEY - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: ba02a597-7863-402c-87f5-87cedc62e7d5: [1,False,RM SYDNEY - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: b41fc4a6-837e-4909-ba9d-54399d40ca5e: [1,False,RM SYDNEY - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: b1521865-b4eb-4583-8bfb-fbd5ead6bd42: [1,False,RM SYDNEY - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: af7e76a1-141b-46b6-a8a5-cf04bb40c8ce: [1,False,RM SYDNEY - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: adccd665-00aa-4e72-83ac-aa8b7a291850: [1,False,RM SYDNEY - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 2ae36886-7696-4c1b-9f81-112d2d1a66c5: [1,False,RM SYDNEY - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: f9376c81-d3c8-424c-aa48-f7ab73831c02: [1,False,RM SPAIN - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: a67d5cf9-fcfb-4f8f-91c0-8194cf1eb0b4: [1,False,RM SPAIN - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 9c0f7656-4ac4-4fb3-8656-2808b11f340e: [1,False,RM SPAIN - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 919d9751-bc26-4367-827d-d4964f5344d7: [1,False,RM SPAIN - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 2c6d8e2f-39be-4023-bef8-06c19c4afe55: [1,False,RM SPAIN - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: a428dcb9-c13a-4bec-9ffd-c9cf379f563b: [1,False,RM REST OF EUROPE - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 6b9fad4d-b2e2-4b5f-af82-6cdfa187420c: [1,False,RM REST OF EUROPE - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 536f9023-0696-43a1-ad08-51019e63feb0: [1,False,RM REST OF EUROPE - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 0b490240-d7e4-42cc-a2a0-2399aafd82e5: [1,False,RM REST OF EUROPE - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: d891bcdb-8e2a-4a06-a971-87e61e32e619: [1,False,RM MONTREAL - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: cfd60973-54ba-459b-a6d2-5a9dd753e2cc: [1,False,RM MONTREAL - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 750818f1-0a46-4955-a2d6-4861e4c9801f: [1,False,RM MONTREAL - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 735f16c3-daeb-4167-b39e-a7b341cc030e: [1,False,RM MONTREAL - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 449d79e6-0018-4ec0-ab0b-e204dbc08819: [1,False,RM MONTREAL - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 42ffb822-5e16-4760-b7d8-115d253c058b: [1,False,RM MONTREAL - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 10cf2066-c155-41d6-badb-9a172a521b56: [1,False,RM MONTREAL - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 718962b1-b0cd-4591-bd82-71e364a87837: [1,False,RM MONTREAL]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: f554beb2-ad59-483d-bb55-75e733bcd8d0: [1,False,RM ITALY - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: ce75038a-426a-4655-8752-c802564f20e2: [1,False,RM ITALY - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 9e567a9b-16f4-4c57-9c83-786d1366b956: [1,False,RM ITALY - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 9d8abf88-49de-4066-978c-0f94e778a1af: [1,False,RM ITALY - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 7da61c05-bfe1-4837-b5d1-e8d750b80af9: [1,False,RM ITALY - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 6a338913-66d6-409f-b542-8b7427066360: [1,False,RM ITALY - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 611c46c3-c3ff-49c8-8cc9-6055af127963: [1,False,RM ITALY - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 59f65080-3ecd-44fa-b096-2f1ab1a2c4a9: [1,False,RM ITALY - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 51316976-bf3e-480a-ad33-ddf0f060b381: [1,False,RM ITALY - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 509ee8ea-770a-47d8-a454-188cc82d8748: [1,False,RM ITALY - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 4056d60b-445a-471b-bce6-2db16ef6d709: [1,False,RM ITALY - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 32ae31ae-7331-4777-a637-d5d9e158c001: [1,False,RM ITALY - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 0870a621-0a12-4946-a92f-954beaa132d4: [1,False,RM ITALY - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 07748c81-5348-4465-b8a6-3f551afa3bf5: [1,False,RM IRELAND - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: ff60d13a-2cc9-41b3-ba9a-a665be1fdbc8: [1,False,RM GERMANY - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: f8ba09e7-5f09-413c-9491-025124542c95: [1,False,RM GERMANY - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: dcfa85bc-b9a9-4382-b090-d40f2d207ecf: [1,False,RM GERMANY - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: d8983815-5402-460a-9ddb-472c49f42e0d: [1,False,RM GERMANY - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: cec806f1-0671-4b0d-b922-c004b92b3c70: [1,False,RM GERMANY - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: ce3a00a0-f9e0-4c7d-b663-02485f9b1089: [1,False,RM GERMANY - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: bf692f58-002b-4fa9-9d07-23149b4ad9f7: [1,False,RM GERMANY - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: bd173af2-34ce-4aab-b93a-e7c7d21d3302: [1,False,RM GERMANY - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: bb68938d-b94a-42fc-aa3b-c1207781a44b: [1,False,RM GERMANY - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: adb5b22f-d513-4a7a-8f15-97a21f63d371: [1,False,RM GERMANY - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: acf2fe1a-734d-4fc7-bedc-7fbb3757bee4: [1,False,RM GERMANY - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 9cc03f44-0a25-492b-b59d-c4ae9fd7e30c: [1,False,RM GERMANY - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 993b448f-9ab4-497b-b2d7-1ce338e882bd: [1,False,RM GERMANY - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 94fe3793-0915-4843-9885-1ca33b7b27a9: [1,False,RM GERMANY - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 8e9d9bcb-6199-43c0-a682-81f039b1532a: [1,False,RM GERMANY - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 7f3ee00f-94be-45da-a8ea-5be2ba5ab2cd: [1,False,RM GERMANY - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 784a058b-4a6e-4ec1-9304-5e6caf0db9b3: [1,False,RM GERMANY - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 6b5b93a6-a261-4f0d-8e8f-3900f2b70189: [1,False,RM GERMANY - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 4fb4a868-30c5-4145-a37e-7239202eaa23: [1,False,RM GERMANY - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 42261f78-27d5-42c1-9768-8a98869c543b: [1,False,RM GERMANY - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 41cbd59b-42d9-4076-8aa1-bdbd37f54888: [1,False,RM GERMANY - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 390dc135-0db7-4601-86b2-4cffcf8fe739: [1,False,RM GERMANY - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 35b8e8c3-b5ba-4b29-98a2-d25ae7cfce61: [1,False,RM GERMANY - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 25a43ba8-76d8-4b59-9d36-fd8035dd646f: [1,False,RM GERMANY - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 1a0a105e-323d-493a-a55b-cd496d8afd3a: [1,False,RM GERMANY - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 16397bf2-1430-4f32-92b6-c012c059de1c: [1,False,RM GERMANY - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 136d69ea-a372-46c2-bb82-61d300985850: [1,False,RM GERMANY - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 11c3fa14-b690-4c5b-9dfe-9d23eb753b36: [1,False,RM GERMANY - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 0b2d8874-b265-45c6-be72-38251928d52b: [1,False,RM GERMANY - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 02dc99c7-c1e1-414e-aff1-9443cbe02059: [1,False,RM GERMANY - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: f8020843-9945-4e19-ace2-cd72886b8770: [1,False,RM FRANCE - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: ce725884-385c-4c0a-8928-426a910fb610: [1,False,RM FRANCE - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: a75abd4c-23c5-466b-a308-e6ee070eb81b: [1,False,RM FRANCE - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 91fbc8e5-4727-4e51-911e-1a2b9888e472: [1,False,RM FRANCE - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 78aa6a12-66a2-4d32-be5a-5af4449b093e: [1,False,RM FRANCE - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 74a9c265-c5f4-4680-8080-ae4225b0b7f6: [1,False,RM FRANCE - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 6ac05486-768c-40a5-8766-8f0495060cb1: [1,False,RM FRANCE - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 567e6620-8f47-4068-abb7-0f9f7d318b8d: [1,False,RM FRANCE - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 5630edcf-c7b2-4f3c-9361-db28f5bd7337: [1,False,RM FRANCE - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 55359202-2db5-429e-9ebb-8b04681ff839: [1,False,RM FRANCE - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 42c74b35-40c6-4be6-923f-76023e897086: [1,False,RM FRANCE - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 3db77550-932c-4aab-8780-1986b631a102: [1,False,RM FRANCE - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 30738c2b-2e4d-4182-b3db-3ad0c7316eb6: [1,False,RM FRANCE - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 268e727f-0f0f-4b10-8d3e-b3e79c7dde8a: [1,False,RM FRANCE - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 0fea7c72-731a-448a-b55f-297fef4e2eaa: [1,False,RM FRANCE - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 000b1b60-647a-4a79-ac46-6c6b1e8bd900: [1,False,RM FRANCE - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: df916b12-8195-4541-9bc0-fa5d37fcbb7d: [1,False,DPD Two Day - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 9ee344bd-0e78-4776-9f5d-bcbbb85ac6c0: [1,False,DPD Next Day - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 9a2b2898-b90e-4736-ac33-c3b0c4700e02: [1,False,DPD Next Day - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 067b7bcf-d78d-4860-b658-75243a434acb: [1,False,DPD Next Day - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: ff84197b-e536-4117-883a-bcf87e073a7c: [1,False,DPD Classic Expresspak - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: cdb797c7-867c-411a-9b67-f5e15109d102: [1,False,DPD Classic Expresspak - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: c46952ca-19fe-4e4d-b228-fcb79aeab4d0: [1,False,DPD Classic Expresspak - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: b8f3cc71-4819-4519-b4cd-03bd1f54d3ac: [1,False,DPD Classic Expresspak - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 87b7d72f-1def-49fc-b443-9d5ea5022fec: [1,False,DPD Classic Expresspak - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 860b4936-031c-47e3-a446-637962127e41: [1,False,DPD Classic Expresspak - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 7fb4b931-56ae-47ff-908f-83c973163abb: [1,False,DPD Classic Expresspak - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 7dedd79a-f02c-47a4-8033-63b483221fe5: [1,False,DPD Classic Expresspak - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 70dac18d-9152-4af7-a45f-3cc00d0ba81b: [1,False,DPD Classic Expresspak - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 652fd3c3-a2b5-4588-bcd2-e1b9e78cb8b3: [1,False,DPD Classic Expresspak - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 625a3390-cab4-4426-ba68-a90946369a78: [1,False,DPD Classic Expresspak - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 565d7b9f-f164-472f-b0b9-4d8975a9f9a6: [1,False,DPD Classic Expresspak - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 56198c73-5de3-4110-8a23-555347e367ad: [1,False,DPD Classic Expresspak - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 3de97972-b9da-4138-8c57-d7004d2efdde: [1,False,DPD Classic Expresspak - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 268710af-0a4d-4be1-b39e-de9019665560: [1,False,DPD Classic Expresspak - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 1df40278-6fe6-45e1-9684-d0438a695b93: [1,False,DPD Classic Expresspak - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 046aaef3-4ad2-4898-90e6-e0c8eda7885c: [1,False,DPD Classic Expresspak - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: ef00e9de-a80e-4154-a205-3e19cf3a474c: [1,False,DPD Classic - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: eefba6dd-abd1-403b-abe4-5a54c7f62150: [1,False,DPD Classic - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: d96b6524-bc92-4c0a-a883-be31f899963e: [1,False,DPD Classic - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: d52c27b7-c077-49b2-945e-5b985fcd5a0e: [1,False,DPD Classic - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: d3644de3-1c37-44f9-99c3-881f299ec74d: [1,False,DPD Classic - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: d26ef10d-558f-427d-a2c3-ff29ac2f6338: [1,False,DPD Classic - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: d138183a-5b41-4053-9283-17779217678c: [1,False,DPD Classic - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: d1047b2b-9f0d-45fa-8e86-1f175cfa43c6: [1,False,DPD Classic - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: d0520844-babb-46de-aed1-8da82917ecd2: [1,False,DPD Classic - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: cbd3b004-7256-458d-a93d-acf01495cedc: [1,False,DPD Classic - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: c4f85ab8-8893-4507-8b43-1a55e2aec07e: [1,False,DPD Classic - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: c38c9491-d2e9-4cc0-9ebb-71e75e3d9e29: [1,False,DPD Classic - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: bbfb3134-cbc6-414c-b411-14f03b501b9a: [1,False,DPD Classic - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: b90921fb-55df-448b-82ca-5c704f38c989: [1,False,DPD Classic - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: b868edea-91fd-4c81-a257-7dd7a050425a: [1,False,DPD Classic - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: b5a762af-6dcc-4681-af59-4bdd360ff27f: [1,False,DPD Classic - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: b1d8903e-0e58-4d15-84fc-f5d893dc87dd: [1,False,DPD Classic - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: adab7fbf-babd-430b-8651-3b2a1074145b: [1,False,DPD Classic - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 9bdc0514-845f-4b6a-af83-80e1773bc94a: [1,False,DPD Classic - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 9a48b4b8-e600-44c4-b8a4-53fa93aaaf63: [1,False,DPD Classic - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 991a180c-85e4-4d77-be13-9439233be9c0: [1,False,DPD Classic - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 990d6606-69b5-4247-b9f9-a7f84cbcb057: [1,False,DPD Classic - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 91e5a70b-1926-4c8a-be48-9d736f574ce8: [1,False,DPD Classic - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 90abf2f5-2927-4b9b-a50e-47e76150fc4f: [1,False,DPD Classic - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 8e43f589-d838-4de6-8473-3d78a9ecb7cd: [1,False,DPD Classic - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 8cf2475e-4fb5-4563-b9cf-d79e9cb06a2a: [1,False,DPD Classic - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 8496b87b-be69-4475-8a5c-4b80cb6d334c: [1,False,DPD Classic - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 82aba3a7-068d-4eff-898f-59fc3783669b: [1,False,DPD Classic - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 82a6ff6c-ccc7-456e-9e70-867283eabc79: [1,False,DPD Classic - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 7dbe183a-acef-4383-8caf-71449e6cf769: [1,False,DPD Classic - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 7c973fc3-54c0-4434-8562-98b63b0c6c1c: [1,False,DPD Classic - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 7a4c64a3-1522-4044-b8d7-88076a8971c7: [1,False,DPD Classic - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 756ff103-1ac1-434b-a78b-8303a9d4a6eb: [1,False,DPD Classic - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 71efc5f3-558d-4e50-8f1a-0ce18ee07bef: [1,False,DPD Classic - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 700b7ac3-d190-4139-9076-4da9e4068004: [1,False,DPD Classic - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 6dc72da3-84f5-45eb-9db5-52c9e10ac5c0: [1,False,DPD Classic - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 685200a1-a695-4a81-9115-e5a8660ce8aa: [1,False,DPD Classic - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 5c3d4c5c-9eb1-4bc2-8aed-c2d0fb20afb0: [1,False,DPD Classic - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 54adbd00-b1ee-4ee9-9fc9-4262dcfde829: [1,False,DPD Classic - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 4bfe3f0f-8503-471e-a729-7a2bbd2597e4: [1,False,DPD Classic - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 424a9953-b7b9-446d-9e5b-10a19ff41978: [1,False,DPD Classic - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 40b8dcd4-9a45-4dd4-abf6-0ffbcfa439b3: [1,False,DPD Classic - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 4083624b-2a07-45f4-8007-ee172dc5fa92: [1,False,DPD Classic - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 3ed3c831-94f3-4344-8e1c-be0cbe21b4eb: [1,False,DPD Classic - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 1da99bc4-d85b-4387-8dd6-dd574e259052: [1,False,DPD Classic - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 1c162d64-e9c8-474f-bf96-3caf2469feeb: [1,False,DPD Classic - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 13a506ab-bf13-4b0d-8518-940d275033f3: [1,False,DPD Classic - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 0f6e0e74-1189-4409-873e-d2e0cbae8c6f: [1,False,DPD Classic - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 05aba421-033d-41c7-bfe1-bbc650e913d5: [1,False,DPD Classic - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: f49bf874-0db1-41e4-9450-6c2c02f4ce96: [1,False,AMZ - One Day]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: f3c67464-daef-4c13-8d85-2943625a8ead: [1,False,AMZ - One Day]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: dfcb130a-eec7-4793-ba27-9d586abb9e89: [1,False,AMZ - One Day]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: d8ecae93-6070-400c-8de6-6430a6179902: [1,False,AMZ - One Day]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: d11ba35f-6564-4a29-8294-efe9d0d36528: [1,False,AMZ - One Day]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: cdf23ba3-233d-4573-a538-04eefa8a25cf: [1,False,AMZ - One Day]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: cc03922b-d324-4aae-a9ef-216adf8760bc: [1,False,AMZ - One Day]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: cbccf400-46d7-40ca-8a77-35258e656bc4: [1,False,AMZ - One Day]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: cb84bb96-8c23-46f8-973d-bd1058f84300: [1,False,AMZ - One Day]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: c97df469-be62-4141-8cf4-a9c9ba6d3151: [1,False,AMZ - One Day]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: c77df67d-574d-47ca-83fa-36284ca074c3: [1,False,AMZ - One Day]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: c227b3fa-0071-4a5a-9ae3-78f917e57dce: [1,False,AMZ - One Day]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: c0326fc7-ef54-44d1-ad61-c81bd7b9d345: [1,False,AMZ - One Day]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: bd7b20de-3eb3-4ced-8b1a-e42c2d8bff71: [1,False,AMZ - One Day]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: bc27142e-afc4-46d1-92a2-930125826097: [1,False,AMZ - One Day]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: b343c596-a195-46d6-9ad9-07616c27a706: [1,False,AMZ - One Day]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: ae1fcc7a-b8f2-4322-af09-bdc60ac42a9e: [1,False,AMZ - One Day]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: a26d7096-9f45-4684-8e1c-98b31e5b7880: [1,False,AMZ - One Day]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 9711c60e-b722-4abc-8633-73eb16746c99: [1,False,AMZ - One Day]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 91ec16ee-7806-4dda-af43-651111728752: [1,False,AMZ - One Day]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 8f16e1ca-5041-46c3-9e46-40524aaf9bef: [1,False,AMZ - One Day]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 8d643d02-ab4f-4d9b-8fb0-6f820f6d25ff: [1,False,AMZ - One Day]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 867c1e52-8c72-460d-8b18-a52ec07916b1: [1,False,AMZ - One Day]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 82cb9f2b-8042-41b8-8bcc-d7dfa56aedc2: [1,False,AMZ - One Day]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 7d6f6404-4ab8-414a-98de-7cc50428fedd: [1,False,AMZ - One Day]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 7d541c72-bc87-4617-b191-e8687dd95d02: [1,False,AMZ - One Day]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 7885c2e2-de1e-4794-9c9e-2dfa6d3dfd10: [1,False,AMZ - One Day]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 774070d2-248b-44ad-97fa-fd8c6607562b: [1,False,AMZ - One Day]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 75a2f269-2477-40d0-a984-d5bf0833e8bb: [1,False,AMZ - One Day]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 71ccbb36-cd8b-46a8-aa72-92ec3fb741fc: [1,False,AMZ - One Day]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 7160b093-cb80-4454-9026-82682b8c0430: [1,False,AMZ - One Day]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 6be21c23-9bae-4c93-ab45-c78fec532f8f: [1,False,AMZ - One Day]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 69b5b444-1a4c-4e7f-82a7-55ef82dfa2ae: [1,False,AMZ - One Day]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 69b18b34-00f7-415d-9ecc-093a2c270545: [1,False,AMZ - One Day]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 640008ad-baac-4ab5-be45-be4fac34f6db: [1,False,AMZ - One Day]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 63ef01f1-e82a-4c7e-945c-a0f7c0f935f3: [1,False,AMZ - One Day]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 5c31abc2-941f-4645-9046-4511237a1a6b: [1,False,AMZ - One Day]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 5b59d53d-f519-4519-833e-c102da0811e8: [1,False,AMZ - One Day]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 5488101b-4b3d-4874-9793-e59cd3e47c61: [1,False,AMZ - One Day]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 4f81a35e-f23c-4163-88ba-4ea71bb3d10b: [1,False,AMZ - One Day]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 4dd4d120-0e76-47d5-92d0-517c7c388ec2: [1,False,AMZ - One Day]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 4d7055f9-c2f8-4ab1-924c-6a22ebc4802e: [1,False,AMZ - One Day]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 48b0f4df-cbf3-427d-8ee7-0beb8ebe2c0d: [1,False,AMZ - One Day]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 3de3d86f-8c4c-4f45-90c1-1ab076e79940: [1,False,AMZ - One Day]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 38d78fa7-7e60-48e3-aafc-2f5d7455ebc5: [1,False,AMZ - One Day]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 3056712b-ad4b-4658-a088-44d2ebdb0b2a: [1,False,AMZ - One Day]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 2e2b9a50-e2d9-4286-a809-c4ca41c8304e: [1,False,AMZ - One Day]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 2a4ec91f-2df0-41a1-a1c5-a7882f03c508: [1,False,AMZ - One Day]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 242fc9ed-f2c5-48da-91c4-0350f68338ef: [1,False,AMZ - One Day]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 22fc17a8-d9cc-41c9-9fe1-968f8d396296: [1,False,AMZ - One Day]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 1c130853-f4e4-4ebc-8185-3e46c2388c6b: [1,False,AMZ - One Day]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 19d8f58b-99bb-43a5-9092-331ed2a0c4f9: [1,False,AMZ - One Day]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 166175b3-e6a5-4ad0-ab47-e64acbefd3e5: [1,False,AMZ - One Day]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 152d3922-7f69-4de1-b9bb-0d1727ce479e: [1,False,AMZ - One Day]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: fe977255-e925-442e-8118-c63ada99c91a: [1,False,48T - PACKET - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: fe838959-2f44-4dbf-bd53-e85533919ae1: [1,False,48T - PACKET - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: fd5a17a5-7aa3-4e63-a5dc-5640b031a9d0: [1,False,48T - PACKET - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: fce581c1-553b-4960-90d3-30cd39ac4e5a: [1,False,48T - PACKET - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: fc062024-b0fd-4b20-845e-1794128e41f0: [1,False,48T - PACKET - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: f9862340-5670-40f2-8741-f51e6d0b29c5: [1,False,48T - PACKET - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: f5cece49-f03e-453f-be0b-56a179222763: [1,False,48T - PACKET - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: f403e954-42d7-4d3e-acf6-344b07fbd457: [1,False,48T - PACKET - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: f2fd0820-2f30-448e-9399-48ce2873c39a: [1,False,48T - PACKET - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: f1d46a43-1190-47cd-9d07-2380aba41ba7: [1,False,48T - PACKET - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: ef62b4ac-5427-419c-abd5-173aa16f4e7a: [1,False,48T - PACKET - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: ee458f34-0014-4828-aed6-42d8bf786832: [1,False,48T - PACKET - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: e92eac93-bc38-4ab6-8280-0883721631af: [1,False,48T - PACKET - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: e8f443da-ef54-49be-b471-f5f727f009f5: [1,False,48T - PACKET - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: e5921012-b3a0-4dae-bba4-20807a3a8474: [1,False,48T - PACKET - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: e051a3b4-2021-4d7c-be26-b7caac64f7b3: [1,False,48T - PACKET - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: dfe8afb2-bd5b-4ba5-b444-634daa826b06: [1,False,48T - PACKET - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: df6acf3d-95d0-409d-a232-4bdeb3ae520d: [1,False,48T - PACKET - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: dc3ec536-3ab7-4f6a-982b-0e5224c55fef: [1,False,48T - PACKET - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: dc06a797-3415-4a0f-ba0a-0325dd6dd909: [1,False,48T - PACKET - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: d8f03863-cfee-4602-9124-ebed405fba5e: [1,False,48T - PACKET - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: d7b100ec-ebd7-491c-aab1-74f2b2b62176: [1,False,48T - PACKET - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: d736e339-ab2d-4196-a728-6bcc209d0b55: [1,False,48T - PACKET - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: d5ab5844-ec56-47cf-b4bd-384d582073b6: [1,False,48T - PACKET - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: d0af9e6a-a42c-46b7-a2e6-bd90a7b4cb15: [1,False,48T - PACKET - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: cf285d25-c7f2-45ac-b2f9-06251eb7b109: [1,False,48T - PACKET - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: ce94327b-bd0d-421c-b03c-f6aa99abd1a6: [1,False,48T - PACKET - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: cb5427b3-874a-4ae8-be1d-c7d35aec545d: [1,False,48T - PACKET - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: c97cc282-7f93-4377-96d8-f7d10076a614: [1,False,48T - PACKET - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: c746b42c-6bf2-40a1-a75c-2683c8f6165d: [1,False,48T - PACKET - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: c6d4bb7b-62ec-4980-b3c8-562b9697dc22: [1,False,48T - PACKET - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: c69114d1-b29b-4343-8615-eaf275792186: [1,False,48T - PACKET - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: c5af8728-d4c9-4746-85ce-454c16fada70: [1,False,48T - PACKET - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: c2a1833e-310b-4a36-92c6-e70f0d4f5870: [1,False,48T - PACKET - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: c0a581a2-9490-468a-b9fb-b7025092d471: [1,False,48T - PACKET - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: beddbaaf-6602-42fb-94fd-5a29fa80a081: [1,False,48T - PACKET - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: b945daaa-94fb-4657-8c89-21f7b2a7dd29: [1,False,48T - PACKET - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: b7f8d52a-a485-4f8e-a4c4-f120d733cfb8: [1,False,48T - PACKET - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: b77a0b59-77d7-4997-9b3f-f8a46a9cc386: [1,False,48T - PACKET - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: b7650cd7-45a0-451a-a650-7bf6acc6ac3c: [1,False,48T - PACKET - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: b75217cf-b30a-4df7-9be4-b27cbca70801: [1,False,48T - PACKET - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: b6e16545-23cb-4723-acc3-89a8be05deb2: [1,False,48T - PACKET - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: b43ea115-a0ad-4472-883e-47faff5d13a3: [1,False,48T - PACKET - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: ac668614-81bd-4f04-b135-2e2a2a6aa1b9: [1,False,48T - PACKET - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: ac4ab5a1-b81b-481f-9005-bc83a515204e: [1,False,48T - PACKET - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: ab4e4aa2-30b2-4d86-a5dd-c57c9d090678: [1,False,48T - PACKET - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: aa9af5f6-2e27-4425-8b06-4a875b4a6e2b: [1,False,48T - PACKET - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: aa73b703-fa3e-44ed-9ef1-656aac0fe865: [1,False,48T - PACKET - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: a6f82dc7-d40c-4c3a-a543-3f99cad57def: [1,False,48T - PACKET - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: a3dcafb7-5746-4a96-9d70-6d38f9654873: [1,False,48T - PACKET - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: a0fd35ea-fdd1-44f2-8c3e-0bcb22c9bfb8: [1,False,48T - PACKET - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 9e349215-ebab-4ae4-97b7-a7bbeb083eda: [1,False,48T - PACKET - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 9e0ef1e9-9d0a-4a85-8559-edbf2242ed94: [1,False,48T - PACKET - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 9bc3805c-f9bd-4c63-a6db-7f3c8ad142db: [1,False,48T - PACKET - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 996d1e50-d060-4746-94d4-94f5db542410: [1,False,48T - PACKET - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 988f8023-cb82-4a08-904a-68da954b78ff: [1,False,48T - PACKET - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 94d97676-7572-4f84-9f9b-23ec93e46d0a: [1,False,48T - PACKET - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 94bbd274-bf94-4f00-8a37-06538f4f4c14: [1,False,48T - PACKET - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 94b04203-959b-4bcc-95ea-73c5780d8fd5: [1,False,48T - PACKET - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 90f8a86f-fbbe-4735-b40a-b1bc697ae9e8: [1,False,48T - PACKET - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 8f17188a-b13d-470b-8a89-5ad3c2943553: [1,False,48T - PACKET - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 8d7e006f-c98b-4639-a2d1-e547c8953c64: [1,False,48T - PACKET - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 8d3f1fbc-e620-481d-8b84-bb108ddcb16e: [1,False,48T - PACKET - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 8c6d3b20-31f0-4a8f-8a7b-c0d706754b51: [1,False,48T - PACKET - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 8b469361-670f-4494-a8f4-4ede4191ce0d: [1,False,48T - PACKET - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 8a74dc7d-2d00-4b73-9f9d-5dfb4cd40881: [1,False,48T - PACKET - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 8a39bcb1-9475-4135-9af4-04119ec2fad8: [1,False,48T - PACKET - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 891233d2-d81c-4745-9911-d46801621a06: [1,False,48T - PACKET - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 866012c0-dc49-4f0f-9591-b34be96ce89c: [1,False,48T - PACKET - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 81771f3d-0c6b-4406-8f43-c7e6c8bbb3c8: [1,False,48T - PACKET - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 7fcdac30-bd4b-4c36-89a2-ee497f409a6e: [1,False,48T - PACKET - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 7c93b51c-6681-4e06-8a87-e81a55b51ba8: [1,False,48T - PACKET - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 7b2dba17-943e-4a2c-9505-6f3882c7e950: [1,False,48T - PACKET - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 7983a807-8273-43f3-ae2c-15e14a705c87: [1,False,48T - PACKET - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 7980db2e-f844-4ba3-9556-8bf3a70b882b: [1,False,48T - PACKET - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 71eb32c0-c2c0-4743-b459-7ee725be4f6a: [1,False,48T - PACKET - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 6ffded40-4035-422a-ab67-f01b3c346d00: [1,False,48T - PACKET - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 6fe93921-73c6-46d7-a916-a174643a9ea0: [1,False,48T - PACKET - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 6fbb74bb-3e39-4ea9-b7e2-c15691d67d29: [1,False,48T - PACKET - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 6e432f91-4a45-4a9a-82d8-d12a4b78a762: [1,False,48T - PACKET - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 67e2cbe3-0bf0-458e-b649-84f047d16551: [1,False,48T - PACKET - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 66c76761-7be5-4795-a1ae-35958b76e0b7: [1,False,48T - PACKET - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 6608b055-8e25-44dd-869c-db56ecc3151d: [1,False,48T - PACKET - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 6472f20e-fcea-4320-9e42-2381f9eaad3a: [1,False,48T - PACKET - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 62c7b340-7eb4-46c1-98f5-e983d2304db4: [1,False,48T - PACKET - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 5eeb65ed-b083-49d7-8504-fd1498df3f8a: [1,False,48T - PACKET - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 5e8b0b98-056b-4cd2-b744-256e5e785497: [1,False,48T - PACKET - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 5e63f102-d4dc-4100-a52b-f75a4057e3c9: [1,False,48T - PACKET - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 5d29dcae-0617-484b-8230-1b8c0f5800a3: [1,False,48T - PACKET - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 5bf7dedb-14de-4d42-9b67-8e2301939bdb: [1,False,48T - PACKET - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 597c7f97-259e-4ad5-bc35-3a86b5b00cd5: [1,False,48T - PACKET - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 58a80a40-b54f-458d-b318-35566973d7ed: [1,False,48T - PACKET - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 5544d2b6-aa2b-4021-8ba3-d7a9f0ba1d2a: [1,False,48T - PACKET - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 5307f9dd-2706-4089-a3b3-64ed361b2193: [1,False,48T - PACKET - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 52faa4c9-039c-43e0-ae66-8b79e1fee354: [1,False,48T - PACKET - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 4f56c13f-b224-4a05-8a5a-3a2617fe3b6a: [1,False,48T - PACKET - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 4b610cf9-c93f-4b10-bb2f-29c21e962777: [1,False,48T - PACKET - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 47b3dd7e-8637-440f-bed7-56b35e273c71: [1,False,48T - PACKET - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 46477c12-936e-4a46-8b03-14d534f7c403: [1,False,48T - PACKET - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 45c50e41-d97d-47e1-bf79-435008ad3bda: [1,False,48T - PACKET - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 457a7145-4523-4a13-81f6-2cc0096eda61: [1,False,48T - PACKET - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 44ca680a-c826-4f35-945c-07e52c2d141a: [1,False,48T - PACKET - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 443ce045-c2b9-4e33-b680-964e8875ac71: [1,False,48T - PACKET - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 4069355e-e876-4ff9-8c01-acd6d5142fc8: [1,False,48T - PACKET - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 3d53869f-8189-4bba-b2bc-762150aea2a3: [1,False,48T - PACKET - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 3cb073c2-d468-47d4-b121-884b0a5c8759: [1,False,48T - PACKET - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 38cc75a3-ffb2-43ae-8f9f-7e28d3dec82c: [1,False,48T - PACKET - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 37c3eb61-5e87-444c-9e08-bec40d235012: [1,False,48T - PACKET - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 35cde69a-2aab-47f9-858a-67f54ffc0270: [1,False,48T - PACKET - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 3445a450-bffc-4cf6-930d-4b529769be6d: [1,False,48T - PACKET - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 2fafed13-237f-42d7-a6ae-df0875549168: [1,False,48T - PACKET - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 2e7a1715-8f2f-4fdf-a00a-b4552bc04b8d: [1,False,48T - PACKET - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 2c2852cc-bc8b-4fc1-ad0a-16d71fb1afc8: [1,False,48T - PACKET - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 29726c4e-828f-4c82-9b02-0d395f4a7cd4: [1,False,48T - PACKET - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 291eb578-b88e-4fc2-9a13-f1dd1c9242cb: [1,False,48T - PACKET - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 282e9ee1-24cb-4c59-8ab9-120d88537861: [1,False,48T - PACKET - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 24e3fe30-4fc1-4478-9215-4974f59e10a0: [1,False,48T - PACKET - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 22d647d3-5afd-4e0d-8a41-9adba9fa2998: [1,False,48T - PACKET - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 1fd7ad20-b215-4300-ba41-9803c7ec433f: [1,False,48T - PACKET - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 1f79d75e-e6fa-4108-8b3d-17e8d0752902: [1,False,48T - PACKET - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 1e4be546-e707-4ae0-b583-037eee127b6e: [1,False,48T - PACKET - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 1d68c4ba-457f-403b-b397-55525d664853: [1,False,48T - PACKET - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 1b2932eb-2b0d-4ace-ad05-33bf271eb01d: [1,False,48T - PACKET - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 1311d166-ae5e-4d2b-b24b-360ab6d56fa0: [1,False,48T - PACKET - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 10ed79c9-bf2e-4d10-8bf7-13a7240d127c: [1,False,48T - PACKET - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 0e75f49b-8d60-4bf9-90e2-9f54e6df42c5: [1,False,48T - PACKET - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 0af51d2a-b472-4558-97fc-b7aa371bc1b4: [1,False,48T - PACKET - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 097153e1-09d2-446d-947c-7a75a686da7e: [1,False,48T - PACKET - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: fefbaba4-d110-4315-ab59-f10cebb27505: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: fe74a90f-b94f-4af3-b565-c99ccb788d67: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: fe12eee7-d8b5-49e7-ba53-6e063057d111: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: fd9d80e1-5bbe-43e9-9374-a462c5912f13: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: fc4992b9-2857-47d3-a241-1a994ad047ca: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: fb9a6bed-4f3c-45c2-967f-e0600e6a09ed: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: fb99fd40-f0c4-4192-ae87-9ffcf984fe49: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: fb8393ea-db54-4fbb-8452-c3cb196440d4: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: fa5f7375-9c6f-4932-9de0-628ed31723fe: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: f9214b78-be46-410a-9398-4bf880092818: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: f88c937a-4455-4413-a484-94bb45858166: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: f7e00aa1-6f6a-40c8-a138-e9affcb637bf: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: f5751450-0f0f-4f85-85fd-49a608d3c6f7: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: f4dddd29-a124-4cfe-954f-5c1fdd09d8ee: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: f4bead9a-b6fb-43a8-b225-f13d6909aa40: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: f49b78ab-612c-4bb3-8390-91129e0af381: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: f33e886b-a674-48d1-99fd-51dfbf481c85: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: f268f4e3-c47b-441a-a17b-ba83b2d393f8: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: f1ec2908-3d10-4995-82e9-f1924f67c6eb: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: f1b1f481-f5b2-4305-abaa-3399ebdb06d8: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: f129c14d-081a-4856-b202-d9b8af7a4b31: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: f0f82f54-ea83-4c35-8647-47b40ed1dc14: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: f00c32bd-3b35-45e1-b8bb-b891d37e4a44: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: ef695a25-d229-445d-9cbb-8322d056a620: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: edb6a232-ca3d-4931-b080-f192921b7da4: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: eb61bb3e-6b77-4d7f-b82d-93c97ba72f04: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: eb424011-9e21-4b24-9e91-9f36da9b0ed6: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: e9dfd1bc-9c70-4c53-b333-51e825ac8678: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: e95bb130-69f9-46b6-bf2b-90eb5bd36717: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: e942ebb2-bea7-4537-91ba-a0d3868e8d39: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: e91a3ca4-097f-483a-b351-e6859f71f05c: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: e690c17c-2d4a-4ae1-aa19-df4379d566bc: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: e5fcb839-a812-4c7b-97b0-f546b9ac49c9: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: e3dc270a-adf1-47bc-8499-ed5ddbc9a7ca: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: e2513f79-7df8-4531-96b6-21b7dd86f859: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: e1ba8e07-528b-468c-b7d0-923657993165: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: e11fd6ab-d954-4a3f-96d2-3dd8c58cd442: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: e0a2c5b9-efa5-438f-a501-37b48c7fc7f9: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: de68b32b-925b-4577-9dff-876b7ef0805e: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: dd727751-39c5-4528-b4af-50450c6d93e7: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: dcf6b836-8903-406a-b339-198a19b5b427: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: dc7b2753-5afd-4a29-837d-ae7bcf818bd6: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: dab904bd-e9c9-4d9e-a082-e5826949a125: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: daa3261c-42a7-491c-8a5c-09ea569c9f1a: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: da001a73-4f79-4307-8647-ad6c2bd3957d: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: d9eb2bd6-f341-4bfd-9c5b-07cf2f025c8f: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: d985ddfd-a008-4305-985d-24000175b086: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: d961321c-2fb1-4e05-a7ee-1a7017c8ad41: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: d85c886e-8e57-47a5-8a6c-fd8555fa4d4d: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: d72fedb3-9b0e-45f6-8486-891d9fd2653c: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: d70a8b30-b5e5-45e4-a248-d619b72a1dbf: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: d60344ed-6018-472a-86e5-81cf82900607: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: d5029e68-44ee-49ba-923b-18aa3f2350ff: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: d4265a52-4497-4242-aecc-1562fa7846a2: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: d416b833-8e9f-4f52-b180-a7dfe23d875e: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: d324b089-cfe8-496c-813c-3cb5fcc05573: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: d2870c5b-1dee-4bf1-bdae-9e2b7616a6b3: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: d1bb729a-af63-46de-becd-ceec82be1be7: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: d1b9e550-5521-4d32-b20d-0564da753a45: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: d173fdba-b39f-4097-ae4b-508a57b922bd: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: d13173c0-47c7-49cb-a85d-b577adcfaf4b: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: d05e46c9-8f87-41ae-af30-92ffd17685cf: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: cc951144-9732-41b3-acd5-12d245aa866d: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: cbdbbafd-e8ce-4a21-a301-20b53b198261: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: cac2498f-5343-4900-ac8b-c4a0e2ebe07d: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: c9860c5d-bd42-4294-8194-198b68055949: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: c8bf53fd-aef0-409e-84be-2dae85c62b80: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: c85ed7d1-c56d-4f5c-89ff-0c4c60ee7ee5: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: c695df03-3a02-4adf-87de-f91f9130220f: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: c563ac2b-bb22-4bb6-b117-091a0f9cef60: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: c4670360-138a-41bf-bbf7-1f6c65d9558f: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: c4004d0c-0ce5-486e-8fb9-d23f44a5ce14: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: c3606676-53a0-4067-bb4c-5c0d2d228e8f: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: c2cd363d-d35f-4d0e-90be-841378cd0856: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: c17c7529-9786-48ff-ace8-00cd83e02996: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: c0748ec1-98f0-4925-a7dd-1762d00b0668: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: c02b24ae-d550-4d76-8c41-0a9f9c9329f0: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: bfda0808-4246-4e68-85ae-aff831b76754: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: bf763189-d241-4e4d-8af5-a5dcf009a579: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: be8b7919-b8f9-4eaf-94c9-22d428862af0: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: be883846-f0ac-40de-b367-a3faf321a055: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: be5cbf8a-1039-43c7-b318-1845070fe624: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: bd9a1279-0d9f-4301-a905-2f104780760b: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: bd1225bb-46f0-419a-9b08-b5c5086b3674: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: bbef5e6d-a18f-46d6-94ea-64e402458f8f: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: bbc51da0-80c0-487f-a4c1-0aa05cd88501: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: bb9da95d-653e-4ad4-bae6-0bc6bcce09a6: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: b9b3b6fb-9af7-447e-96a5-a0cf7ebedb33: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: b7f65e42-dc5c-43e3-a7e9-bd2888ef142e: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: b648609a-443e-48a7-aca7-581d8397c94c: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: b636a0a6-d3fc-4753-a344-e9b6c9f7f3f6: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: b53fcb18-284c-4058-bd3c-f7e2243dbc3e: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: b208d7db-8380-4f5d-ba91-ce43100c43e8: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: b0de3534-602d-4eda-9453-dabe2aad4e68: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: af486aee-61d8-47e5-b3d5-1f95fe25c4f6: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: ae46f09b-2b5c-4c86-9406-b9a24de5c15d: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: ae02860e-594d-42c4-9529-5f5ef53d0394: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: ac9420e4-4645-44c6-96cd-28f5d8361b74: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: ac38b4f8-eb29-4121-9bf9-ac5e1290e962: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: abca20fd-ccdd-4e07-809f-7f7e35bca140: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: a9a94122-dbfc-42a7-b39c-666b74df98eb: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: a8d3175a-ce20-4132-8a4c-cb406de55f95: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: a53f2782-5ad7-4938-b522-fb5433471473: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: a533a67b-c440-451e-9661-f26a35736c2d: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: a5214635-1412-4b2e-8904-39477be40369: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: a39c8ed7-e585-4809-8314-a41ec995aaa6: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: a3790182-26d6-4e7e-8013-ad7ce5c554d9: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: a2b70450-08b7-4a67-9c84-0c20a9a20a36: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: a254b661-e86a-45d1-bd5a-f594f29a5a97: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: a0bccb4e-1c42-4a82-a983-6672c42f5d65: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: a01a5189-2d88-4d2f-9812-103866c38e4b: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 9fd08bdd-ecba-4f41-839f-2bebf2b51f19: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 9fafbb2b-1621-41a1-a901-9832e68a8d5d: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 9becbf39-f8db-4ba9-ba39-fa3caa9fe773: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 9b51d176-0c17-4040-b8d3-9ddd4ce72034: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 9b47e392-b958-4ebb-b0e4-6559ad0b7c1a: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 9afcb6c3-a764-4e24-a5fc-9d2c9ab2e16d: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 9add27d7-860a-4e14-8b7c-0fc30a6d8e2b: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 9a366331-5725-4ee3-af36-49e7dfe10b62: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 9a2af65b-74c3-4893-a593-5021dc07bdf7: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 99e18c78-dba2-494b-835a-b7fbebf60352: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 99cc7c62-bb44-48ec-b863-cc2782ad8054: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 995fb806-9957-4b72-a0c3-3cd992951977: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 990e09ba-aec1-4564-ba64-05e9b9be8376: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 98333a20-6518-4f11-8c30-e872c8ca0762: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 976ceaab-dc2b-4b83-b617-b97bfa26f7fc: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 96dac2e3-699d-41b6-9a24-4b7200acff4d: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 9653ebb2-d122-45e7-9353-c08a9dd2cb4e: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 951461b2-e12e-4f93-88b1-c4e686dd3f87: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 950a10c7-c531-402d-b764-d93d2564a459: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 93e5f924-93f0-4bf4-b1dd-a5238783b7a6: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 938fbeab-a941-4326-8b8a-d9fc6b87d1dd: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 935bea59-a220-4f0b-9c47-84308d9155dd: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 91ddbad7-7f47-409f-9e3d-2eb61750aa0b: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 917b6ed3-ba7b-4b92-80ee-bf4d3fa43615: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 90c565cb-622c-4e70-8bf4-defb581db44a: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 8ffbbffd-873d-4127-8e06-36f8b8c8298f: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 8f529973-5c98-4fad-a513-b3887bbbb993: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 8e7b45d3-d724-491e-8b6c-4838c40f8ce7: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 8d96d5da-320c-4c50-9a3d-4a30b1cb1e9f: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 8d663e08-a0cb-49f1-a0eb-aabf167c5ea9: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 8c33c7b6-de11-4fd1-a4a3-8781282c75aa: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 8bb95a6b-8231-48bc-a9d2-bb1d8782b361: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 896b4606-a67e-4418-bef9-828334bc453f: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 8910b9a8-637e-4e23-9c27-81ebf19b335a: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 88cd07fc-b8c0-4ef5-b709-73a2d8ce5d34: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 874d2fcd-c64e-44d6-afc9-2a3883c8260b: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 87149587-f223-424a-9473-a34336a6c864: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 855b5f72-02d8-470d-bd08-1e3d35ceaeb4: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 84a3edb4-6a35-4836-9d36-2a313e781870: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 83135ab8-9bbf-4287-96ed-ebb8af84bd95: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 81a9a7b5-c6f3-4230-8a86-5896d8f0840b: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 8055bdf7-93e1-4343-9f96-f2685fccbca1: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 7edd9937-d21e-4fe6-89e1-f4f21df0a9df: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 7ea9461e-74d1-4eba-aef4-0ec76808d586: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 7e1bb487-7031-42dd-bc3c-cd4105b367a8: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 7df069e1-044f-49cb-8325-d1f7d40028ef: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 7d0b0159-1898-4c4a-8f02-390037631275: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 7c847de4-8963-4658-a308-3f75d81f6f37: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 7c7989c6-705c-4349-93b4-a09782bb4c9b: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 7c6e567f-2934-41e4-bbce-f40cb9298080: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 7ba64b58-9d1c-4b04-8faf-31de7289bed9: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 7ba028f3-04e3-4158-bfa2-68dd3408001b: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 7a4c6583-d179-4960-ace4-310a1e04e77e: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 79964516-3618-4054-99be-1349a0e60ee7: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 79388032-5dfd-4ea8-9d26-4ea3249ee847: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 792e30dd-f88f-4a93-8a6a-e003807b470e: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 790b5718-3857-40f9-aa76-b03a5b5222d2: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 7896d2c2-5a77-4707-89ee-61a096f62ea8: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 77d2ea5a-1332-46aa-ba6a-1eee1ebcbfb4: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 779e6374-cc37-4739-87d4-c36fbd60a464: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 765c4fa5-688f-47b2-a41c-cdfef27877df: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 709518b6-345c-4fed-a021-d84275ebdbf0: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 70590d48-ab46-4ce8-b172-0c5b8bad84e5: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 7015b24f-3d4b-4375-a4bf-a5ec806e620d: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 700fe089-a6a7-40ba-bce2-7311036b9642: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 6e887f7d-08d0-48e2-af67-5a6899f14d13: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 6d530ec5-9690-417e-b7ef-1c267863f28c: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 6d04a4fe-4393-4fc4-a62b-fb4635f5c418: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 6bd9d4e8-e605-4217-a2ed-1b6b4580f9fb: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 6a26fc62-8919-49ab-8ba8-c5311ceea262: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 6a04a585-b263-47ff-8a1b-449286f3030d: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 68749d52-76df-411a-a8df-bf70244183f7: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 6724055e-8a3f-4656-b2ff-91ca38b9a3d9: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 666e51ef-f739-45cd-b28d-d8778a4ff6f3: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 65510e55-f9e7-481d-9782-45e8c49cde03: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 64f8906e-6fd0-431a-8220-f999f29327de: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 6315c08b-54d5-480c-9ef2-296a1b1b2086: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 629e0425-6e50-4a38-85b7-726ec51cb06b: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 61204a02-b90b-4a0c-9c81-0b591cc068f8: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 6110b300-8b13-4417-a36c-29fcdf17a69b: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 60be3af9-70e7-47ec-9e9f-ad098d72b163: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 5f7be2d1-ff78-47aa-ab6f-2e5ccb5ab244: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 5c1bf8cc-7b9f-484d-a462-3921a3e65e3a: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 5a951b82-d172-4eca-a1c5-102e3a5f507a: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 5a17b0e5-469a-4428-8bb0-55f92d7a4277: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 58392bf1-9a84-4739-9d59-c653d23d860a: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 572d153e-d59f-4306-8bbe-57ee1edcc046: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 562676b3-b54e-4a6a-8ba9-595c5245422b: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 549248a4-7c29-45e1-870b-3052841cb124: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 53d3e36b-6b77-4239-b622-a7fdb1362a43: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 53aa520c-1cc8-4748-bfa6-f4570d573a4f: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 52e62af8-0be0-4367-8d45-99e3b090c35e: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 518285c7-4a86-40f2-bbb5-2b92718b4bf0: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 508f50c2-83a2-4659-92da-8af7fb32dd9e: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 4fa8602d-77f4-459c-a422-9e4c61c82589: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 4ebf59f9-a9b2-4973-968e-c463f87211ca: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 4e92cfae-7b8a-4c03-8b3c-7f6164a5dd19: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 4e5acdfd-9e8a-46f5-9ae3-826fdd2c8f14: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 4d2cfcc4-c9b7-47a6-bbec-33a2d1e27966: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 4d1aa49b-218d-4090-87eb-811197fccfe9: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 4b4ffa43-e1df-40e6-b47e-e97bd10e1a8d: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 4b44c781-5aa4-40ef-8502-c949b0b87bfe: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 4ae14278-dca8-4441-818a-dbba749155c8: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 4aa506a7-0e7a-4fdf-9b86-e1cc311ad519: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 4a588afa-7121-439f-af1a-e1c9a219472f: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 4a3fdd43-3132-49b8-8911-a33b87d2a769: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 4a32775a-1d28-4735-9e33-8be721168d41: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 4a2bb0a0-9a0c-4788-8b04-7a521e541685: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 47593919-da79-43a8-81f6-4ea38db29e18: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 46838212-5914-431e-b822-806c4436973e: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 4642eb4a-0c07-44b4-bb58-ab69c76ce3ef: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 4617ceb3-bce2-448c-bcee-80abd078c8d7: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 45ec18c5-042a-4e63-a14a-f5e03cb202c5: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 4577df55-5378-4ca9-b1c6-c5acaf0c054a: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 45374956-c40e-48bd-a3f1-e374763164dc: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 4456130e-a98f-427b-a302-993f41d4caa4: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 4422f94a-1aa4-451a-ad39-600236a1bc8a: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 41b28caf-b476-4acb-b794-be14af20bdcf: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 4132464b-c861-4b79-9b9c-e959d433ae34: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 3ed26646-704f-41a2-baaa-9a6dd37792f0: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 3e9ca7c2-45e2-4c34-9d12-c07f7f12a685: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 3d5f161b-4502-44b9-9936-f986406f6350: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 3af253cf-72b8-427b-91dd-d991dafa55a4: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 3a5937dc-9d2c-4868-83b1-3ce72418cc6c: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 3a0b9b74-63a3-4bdc-aab2-434a584189ca: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 39681156-1aa0-4fc4-83ec-adb3e5b1f77f: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 38227a88-b904-4fc3-b093-83db97de8fc0: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 3773ed97-5458-4d85-9b5e-95640f09ac1a: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 36e1ddc7-bb65-4c77-a7dc-038d1fbd1cbd: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 361d690a-93e8-4389-9500-f0da685e75b3: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 352a67ce-0c1f-4966-bab3-7f3e63bb2000: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 351379be-3bad-4c8f-9e05-df51b2fd1969: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 33d5d395-e516-4570-9cd5-41fcec0307d4: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 33616102-0665-4336-bd5c-c0ed11998ca0: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 3330d3df-2d77-47b5-b1e1-65b58aa91240: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 32c3a3a9-2675-4cf4-b8eb-d1eba354b0c6: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 32a842d1-a176-43a3-8886-6deea5c9f2ce: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 3243fb0b-7923-42ee-b64a-731b91eb9f38: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 31b3550b-84b6-44a8-85ba-936695e7cbce: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 31072e22-2256-42e4-822e-d791a06628fc: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 303b1809-bb75-4727-9d66-b31469f2fd4a: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 3010aeaa-6152-4aec-a043-b9647a1b2717: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 2ef397d7-5a85-4805-a684-1d5a8f96364c: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 2ed5220d-a7c2-4387-af80-6ce0042b9bfd: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 2e66bf44-7556-4885-aba7-10e13abff283: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 2e65a7af-2d02-4872-a4b5-04da5db68513: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 2c747af2-c0a1-46aa-bc6b-f4eee929968e: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 2c5e79ef-b291-4875-b3ff-d4ec816be201: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 2ba186b5-38b6-4e36-b386-f0e90233ae27: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 2b9092e6-c2e0-4a4c-a5da-b469738aa2a8: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 27726613-106b-4554-9ffc-324aa2f08cfe: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 2732735b-7841-48e9-80fa-8b83e9e3e7f6: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 263b0e71-4948-4fd9-abdc-9264bae944f8: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 24d5f113-7fa5-44ec-b732-7b2600c9af80: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 248eeb1f-f039-4d7e-9d59-2b5039c02528: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 23fe8b23-9049-4f09-96c9-b1c13dee0916: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 23829ce4-d980-477f-9dea-ffc9ac82495c: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 210f4cb5-a32c-49d7-8cd0-b2c02b6cf846: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 1f8bc1f3-666b-4a3c-8099-c390598071ae: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 1cf9ca6d-5eb7-4307-b609-1e3e30427d44: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 1c2dbad8-f702-499b-93b9-58a392966f35: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 1b70f444-2eda-40fa-8b5b-d863f7104adc: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 1a7b386c-47d1-4c77-9f2d-1c952f52423d: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 18843257-8959-464a-875d-1e7a37c3a2af: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 186c7d2b-7a42-45ad-b7bb-052cafa987a1: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 17d7c85d-8c5e-447c-9a1a-a13d19ea2beb: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 16200c0b-ea7d-4e0e-a5ef-c29361c847b8: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 16157773-8260-4c73-8133-0a5700685f5c: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 152d036a-00eb-45b5-99b2-0fe6935d3780: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 1424d268-211f-48e3-922e-a2c220c66ff7: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 13975e17-140e-4932-ba6b-25ea35a3a6f9: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 130eeb74-61b0-44c0-bd9a-c7c821d96dce: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 12179225-0d0f-49a5-b3d2-342e16806880: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 11ed74da-f9d6-4985-9771-38b544ab28d5: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 0f0276f1-bdca-4bc3-82b4-9ed3a1fc43cd: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 0ef23546-651a-4d39-a4d2-2e62e1a1c539: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 0e1e2c24-801b-450d-8276-d83cc3265eb1: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 0de0c8c0-1757-41c4-a09e-640ce29c722c: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 0d25273a-fc34-4ac4-860c-97776df5263e: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 0c3533bb-35d1-468b-bd9a-6cf8cbf94236: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 0b20dfbc-7354-4813-b464-07579a6d94d8: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 0a3293b3-9e73-484e-85c3-4b2d8d25ad5e: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 0a2859af-3692-44f6-9616-de9144e4d4b4: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 09686b45-f237-4f45-9657-1100fa805cfb: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 093ae80b-ab77-4f50-beba-8cf772a03315: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 08c78fe2-e1bd-4ab9-a3c7-75b06cc70817: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 077b3dd7-1198-47d2-a33f-f832fa0e778f: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 06f4417e-4067-4a92-bad9-0d8dabc6b1a6: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 0606099f-828c-48c7-9940-90cba11cb26f: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 058a9391-4be2-4bdb-83c4-59daf4557951: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 0496c6c4-c613-4360-8f2d-cf8d3a5503b5: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 0475f8dc-40f2-425c-9b87-dce345af3129: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 0335786b-72ef-4ffa-9a0b-d6931dc86cef: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 0262dcb2-ea62-4a82-8922-04c031ee77cf: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 01ee0859-7a28-461b-9f8c-9b66a3a2769c: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 012af680-47c8-4091-93cd-367139712d8d: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 005a6012-1132-46ef-a3d3-723c9fc6aee0: [1,False,48T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: be29b15a-3601-4a49-b37f-d8eea3eb9578: [1,False,48 LETTER - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: f8e8c788-0bf8-4f92-a8a1-06e8b7cb1535: [1,False,48 LARGE LETTER - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: efbfa8b7-7dc3-47f1-8391-cefa07434187: [1,False,48 LARGE LETTER - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: e7ee429c-1c27-4d5f-bafa-bef65cfd9f38: [1,False,48 LARGE LETTER - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: a6054c57-e192-4a44-8777-f29334762898: [1,False,48 LARGE LETTER - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 94ccc311-21eb-4c5d-aa75-bd05bd5307d8: [1,False,48 LARGE LETTER - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 39630311-cd5d-4d6a-80e7-9e13634cb7c3: [1,False,48 LARGE LETTER - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 331f1418-e1ce-4405-9dc0-c6f2d4e9b44f: [1,False,48 LARGE LETTER - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 24cf9003-1d89-4377-b0b9-43a51e019693: [1,False,48 LARGE LETTER - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: fd0ede1a-eda2-4ad3-8eed-b69659457096: [1,False,24T - PACKET]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: b7281123-c893-4078-869d-b97f1e81fe23: [1,False,24T - PACKET]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 5dce33ff-eb30-4434-9ef8-1970fae0afd0: [1,False,24T - PACKET]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 5c33a3b1-3770-4fe7-be10-6330f304102a: [1,False,24T - PACKET]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 3b7d1faf-340d-4024-a23d-30dbe0e1ffba: [1,False,24T - PACKET]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 209c4bd7-e167-43c5-826a-f20db2e054e3: [1,False,24T - PACKET]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: ffac29b7-10ad-41cb-9db0-530373152f33: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: fdc5c72a-eb53-4aa2-bef4-afc95537acbc: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: fc976a85-ccae-4aec-afc0-4409b32d0c31: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: fc166e2c-d9b3-4640-bbf4-292b1ed051d5: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: fbd9ee30-ea0e-4e79-8579-d943c90c3b5d: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: fb26f9f9-b6a0-4a00-8959-2d65c4c9c02b: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: faca86bf-ffef-4501-9245-e57f8e55df01: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: fa25d1af-cd4e-45d5-8747-24502f5d8e31: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: f970dfba-f29a-43cd-b843-bc8b4991db76: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: f95418fa-46ec-47d6-8db2-8d074427b54f: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: f7c7e496-4adf-4c9c-94de-3637ed123254: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: f766857c-639d-4d19-a717-c0d5f30938b3: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: f6c30cfc-b7aa-4713-9816-fe3033bde9ee: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: f606d972-93ad-42ff-9d6f-0df5b15f2495: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: f422d455-5992-4ae5-8687-f3fac4a887a2: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: f24d3ad2-a522-42e6-8950-6eef6e478042: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: f2481054-5d87-43b7-82cc-437924fff5a7: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: f1c5b7a8-030c-4b8f-a43e-f89a6aec987c: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: f0fd62a0-b812-4acc-9df8-9f5ffbafac86: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: f04802ef-b696-4587-a028-00ed6ff275f0: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: ee9f08a3-b538-47eb-a1d3-4166711fb84f: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: edebf866-1315-4df8-b4bc-4587e5fb3142: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: ea5bf5d0-d9b2-4bf6-8899-41a685dcf047: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: ea033ab1-2de7-491c-a62f-b873308e940a: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: e84f98fb-20d3-4c5b-bea0-d70f35ca99a0: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: e80d6164-4835-4795-82fb-7c1e4966ca38: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: e62806e7-a1cd-480f-95f9-9c3c8946cd3f: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: e55ee467-6806-4c2e-a34f-b42bad1c0cd9: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: e5167004-1432-4a3a-99c5-53cecf2d810c: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: e4157259-4621-4103-b965-6ba701903d35: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: e3cd20ce-a525-4074-b5d7-c22f997d3bca: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: e3c0b1be-fff4-4ffb-a920-f0b8ede51c00: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: e36b669c-ee56-4ad1-81a5-72107422aa28: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: e1ebd58b-1bf1-4dcf-b9a3-8f6660e65f37: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: e1693149-6cc0-4720-9b69-965c1e77f5d4: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: e01fa5bc-9a01-4840-bf45-c154a5ae340c: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: deb9c74f-f502-44f2-b6c9-b2b1bc6b6743: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: dd03e36a-58a7-4b38-9fd7-6e0de85def13: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: dcc62bc7-b34b-4607-bb89-88211b81d572: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: db17c553-f9d3-4a59-b380-9a9b51541254: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: dad608f8-7694-47a5-aae6-154fbfa3232e: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: d903459b-2f77-45c0-9837-328328ea52e4: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: d880af2d-b6c4-45e2-b9ca-6f029f157f45: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: d803295d-7130-4887-b981-abc0b89096c8: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: d6710a39-a2cb-47cf-8bf0-6c2ea8d3b173: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: d606cf67-130b-48d6-ab86-e1e4fee428db: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: d5a3aa5c-5a36-453f-85d4-f0fdc916ae67: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: d59e3754-1938-438b-8577-cbad4ff8fa11: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: d395bf3f-bd92-4626-af11-959dc6f97a23: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: d33a3ede-9a72-43cc-8ac3-868d83f06f86: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: d30d42d2-855c-49ef-803b-10074dac27f0: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: d2893b0c-197e-4113-ad9c-308a30e48970: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: d2698670-3c80-43ee-bc8d-e74a39383dcd: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: d21ee913-6a61-4bd2-8f14-a78a233cea83: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: d1e386fa-2425-49aa-af6e-11334b29fce6: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: d13a75f5-ae0d-40fd-8c9c-a1ac56d23341: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: d0777ea5-b6c5-450b-a392-afdf97a8914c: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: cf016535-1152-4c9b-b819-3640280488b4: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: cd1ce10f-85ad-4199-b2d6-802f6a9c7e04: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: cc927cf1-f459-454b-997f-33f42815ad82: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: cbc361a4-9ecd-4e4a-8039-67126c0ea45e: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: caa28c20-a81d-4e82-aae5-765ee48414c6: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: c9643f8a-90ff-4219-bdf2-1ef9003c50f3: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: c8e8671a-690e-43cc-9f8e-2cb5a7779f56: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: c70e4cee-d21d-4575-a692-da905763eb93: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: c471b994-9781-4ae0-8559-e852d565dea9: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: c402c385-4d06-495b-8ff8-28e80d17aed1: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: c2dd0396-9be7-4d4d-9788-22f3023c4601: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: c2bba3b9-fda7-4549-80cf-ed641adc8411: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: c29e4fa5-f06f-4feb-876c-89274f516704: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: c2047e37-f758-4179-b4b8-8ae5f6983c33: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: c0e6ab93-0951-4309-b9fe-97a106155b92: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: c0b7b06e-d9d5-4284-bf4a-5854a1f14d05: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: bd61f916-1b16-4b5b-967d-3da5923d8c47: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: bc8021f8-9f70-4057-ae61-4bd01608212d: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: bc0af218-d478-4094-815a-0e583cb42beb: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: bb0a8926-96d0-4268-8c69-5bfdba0548c1: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: b99c8f3d-7321-4abc-ac73-a3bfcc76fb57: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: b847b36e-b51b-4c4d-877c-fb3725beec67: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: b8460163-bfcd-4945-b0e2-024884b987a5: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: b7fa2650-8f61-4038-8459-5d90a2475959: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: b6706f3e-e6f2-482b-9a0f-82168a249f7d: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: b5c1d047-3670-4dfc-9a32-a2b4867b749a: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: b57fea12-6a39-44e5-94f0-7149b3977465: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: b504b17a-2c60-4161-9e31-96b4db5e3fd9: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: b0f7e369-d9b8-4ec4-aa76-c517b80c21cd: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: b0709376-38b5-46af-8502-1ddbbdaf7178: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: afea3e2f-366e-40d4-9255-6a30c00c36c1: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: aee5c3bf-caee-43c4-a77f-a2f233ce2efb: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: adc57459-498c-4131-9bbb-79cf15b11a53: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: ad264240-d2b7-4bc9-bd0f-7799c3733cc3: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: acfdc0a4-e04d-48c8-8220-33b84ef8c43d: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: ac790592-b9e0-47ed-a4e0-68e5b7bcf4fc: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: ac22bcee-69cb-47f5-9dd6-bc75f03e28ce: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: aa44540f-418b-4510-b3cd-d9cd2b911fa1: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: a937384b-864d-4ca8-bd72-e13c0912096b: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: a86102f6-6378-4875-ba49-0589f429d24c: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: a6d4710f-3f32-4aa5-a762-7700a00df32c: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: a65da3f9-7547-466d-a636-6cd7d4b20bd5: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: a453c52c-4874-44d9-b8ea-5f9017988a2b: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: a413269a-409d-441b-8d37-f8fe57be235f: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: a2e91a8d-acc3-486c-84f1-4c5b21dacf8a: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: a27448d0-6054-4aaa-87a4-215394692925: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: a18bbcee-368c-4a6f-8d96-5cb251df9680: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: a05b494a-7175-430a-a725-ba5a9fa05b61: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 9fc71dd4-e84b-442e-b029-72c309a75206: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 9e31897b-70d2-455c-92ca-2114b40a2252: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 9e2caee6-7b5e-4d3d-9243-cd33f7e12d68: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 9d30356c-f16e-412e-aa86-20cf968786f2: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 9c77c902-ca1e-4943-80b3-c52806a0a4eb: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 9c52ff14-0eef-4284-b934-820a7d8ff132: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 9b53845e-1d78-4d01-96d5-f089c51b937c: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 9b4108df-6cf5-49a7-adad-8a1d083b1fe1: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 9b026bad-663b-4d9e-b849-1ea7a7f9ea69: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 9acfc16a-cd37-44ad-bd5e-8b64a9469e59: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 99cfd61c-d297-4b73-bd39-05be1e5c03e9: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 99b4ca8a-d448-48b9-b02a-f1b4f8e2b440: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 99742c5a-5529-418e-b1e9-8058fb16af39: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 9928d73b-e5e0-4e01-b159-56a0835a57ac: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 98f6b114-0f70-42bd-aa65-002dcc0a337c: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 9837e30d-4ee2-4b4e-ba39-e72fac9a9e77: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 970f47ce-4492-48ba-b85b-3ca2793cd1c3: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 963e7522-6eb4-422b-b264-c17aee9835e7: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 96169a2a-daa8-4071-9d51-1c7c4cdc1029: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 955a5cf5-ca65-472a-8716-043a2202afb9: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 94d42537-993d-48f5-b479-859217c18ce2: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 94a041cd-26f4-4a0e-975b-584e7d3aa925: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 92d73e97-3b67-47d1-9275-b5d89c2d87e0: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 91e8c9e8-0e8f-4c44-a4bb-aa99e505c1be: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 90bd2c2a-2293-4696-aa3b-65b548cfa04d: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 8e1b43ff-e69f-4015-9c96-8940fee08ed3: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 8c7d818b-3327-4975-8cb2-f15016bae29b: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 8c5c8d6c-6688-4cfe-9097-462806f51e96: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 8c3dd782-559d-4ea0-9e1e-dedaceca6ea7: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 8c106f3a-02e6-4fb9-aecb-302a4b0c2363: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 8b6c3236-5a0c-402a-933d-4299ec7561cb: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 8ae4b536-dc87-43b4-8e63-9ca0bfb4ddf7: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 8adbde62-eefa-4248-8c2d-442fa6acd2d4: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 897a47e5-7c5f-40ab-a08b-aaaa5c6a75e3: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 88c85048-fc1c-4bd5-81e1-5df23618b2ba: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 88a870a2-3e4b-4cb4-9285-327bd9a74cde: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 887878bf-765c-4884-97aa-60020ccc5568: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 87eaf16f-93b0-4bb9-9da6-4ed6df1869c2: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 8523d51a-634d-4617-9cb9-08f04acdb6df: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 850f8fc7-0fa8-4718-8881-9ad477e3a666: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 84ee9fdf-2215-4857-aeb7-149ac43a86c1: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 83aff62e-cb08-480b-8c41-f9e6682b7bf1: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 82e7db7f-5738-4008-9baf-0c09eb746e4c: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 81e4e328-250a-4000-b860-d13100a16129: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 8196dba8-982d-44e1-902a-9517b010700d: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 81389f19-adbd-41b4-a031-671fdf20fd2e: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 80c77cac-971c-4647-bfbd-bd0defbb3982: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 809ad70b-97f7-4ceb-aad7-ae2548732f4b: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 80387496-8230-4fdd-82bb-5eb6b5e180cd: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 7f325d06-0df6-4ce5-ba14-dafc6c9a453d: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 7cfdb6d2-292f-4da7-bf0d-5b209c88fcae: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 7c0027b2-ec63-4360-9e47-1e1f28019a72: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 78376182-7434-47ef-b488-848a84ea190b: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 776960bc-0ef4-4dbf-bd38-67892c9816d2: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 76dabbe8-99de-4ac2-991a-87fd0163be7f: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 7636ab03-aaae-46cd-b555-3114f17c5ce8: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 751f36fc-5121-4a2a-be07-e40bacd111d4: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 74cb1f56-8c28-4fa3-ac7a-e50e075ad154: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 73b5cb93-2544-4256-b64d-be5c65e158f2: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 734a2ec1-dba3-4ac1-bfba-a6940a916c02: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 72a46b1b-9ff7-489e-b41b-1a6e5e7827a9: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 7291b8b8-1f6b-4082-a7b8-59b20f0e3722: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 724fcba7-d646-48d5-8420-de05982ee64f: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 71f7ec6d-4d94-4cd5-a9f5-ce16c761df53: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 70e70caf-4c5b-45cc-9721-e53fd642f4ca: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 70ac4b66-6989-4796-9822-e91f90cde06b: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 6fe7d03b-ccd4-4972-a868-ce95f36452aa: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 6f925d38-a18f-4675-aae4-a2fd992c245c: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 6eaaa882-8339-4698-933d-79bd0c7ea5cf: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 6e05b2df-8c1e-4efd-94f0-45e73e02fe59: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 6da1c70e-b24d-429a-842f-487f2e4bc1b2: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 6c63005e-ba4a-4fee-b81a-b90b91ea18ca: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 6b97eb9e-2042-4cef-8845-86629c3236b9: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 6b696a43-799a-4782-a920-c190685ba53c: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 6afa8cf2-cae0-4112-9675-022e33d73f2f: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 6a9cac7b-5ce3-4fac-bc34-ee6a5166fb3b: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 69e29a2c-1a77-412f-b75d-cc37a4d512f3: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 693810fc-5d49-41bf-b4fd-24255f74aa00: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 68d948c8-b68d-4569-aef8-fffc2cf6fa61: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 672ffd69-ab67-42bd-8fd7-2d636f3f3b0b: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 6707769f-ee4f-4a7e-b574-2080dad95a89: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 6588acd7-5a91-4d2a-a3c7-f71f8bfe79d7: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 65573094-8a6f-45a9-9b4e-61a9c0ac62fc: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 64183671-fe7f-4548-bb50-e98161d582a7: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 6344c2d4-2974-4d38-a62a-4971b41791f8: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 62ae2ecb-437b-4532-9144-5aa5f81d3ee9: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 62938a4f-8ccd-40e0-b7f2-68f573512375: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 62653282-14e9-4dd8-8698-6dc9958fa9a1: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 605233c2-17cc-401f-af20-82bd9a5f3ac2: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 601224cf-8c68-4480-b6ce-a9a9e35a89e6: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 5feacc0b-8eaf-46d1-8f19-ee80198cd309: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 5eb50715-f959-4139-8226-b242a9466b5e: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 5e9081f5-87d0-43f8-af04-5f085206a441: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 5e65f6f9-fdfd-4bf5-b8b2-1bf637221200: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 5dc17ba0-281e-4961-8c6d-7ced09c9878d: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 5d6c4b68-4612-46c0-bc04-ed61e1c59281: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 5b621bf7-f2b7-4675-b66e-a917524ae82b: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 5a2ddd5b-cec5-4008-8dcb-78546be3a7ee: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 5a2a9a01-c45a-480c-82ef-54a4ecf0b69d: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 5552ba66-d7b9-4275-bbc3-963c5976028f: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 53e3f3a9-e577-433d-bcc3-61d5f82de8eb: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 52def4a8-8160-41a5-bd43-660db90d9982: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 5185dee7-44d7-4d5b-807e-d0fe76d2fae0: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 5055802a-ea5a-41b0-91bb-3347776c6f9f: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 504b28cd-280c-4729-867b-b78c046f775c: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 4e902f59-1d7e-45ea-944d-ff41d9f96f05: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 4c4c1d6b-6b10-4992-a2ee-8741fbd6d2d0: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 4c237c2b-df3c-46f2-b6e1-256813450823: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 4ac1d022-1674-4f3f-a07a-11997fdab895: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 4aa3c752-93a5-4c94-bc6a-4953c2850f23: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 47f49da4-6703-4df2-ab19-c60d2ae567ab: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 479b6f51-fca4-4911-8654-1396b199dd3f: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 477c09c1-37be-4625-98b1-c6cfadbeb736: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 45db6bbc-95ae-4f51-8c69-56e769d209c0: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 45887517-e538-4325-8581-764b420282bb: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 44a0f673-a597-4e27-a77e-da2799a49f06: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 42fb5da9-7d2f-462a-8e30-700862453e1a: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 427081c5-1ea4-45c7-82b3-6ab6cfcb2f99: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 4238c121-4fec-4c6c-bb7a-260863d1c698: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 422c7acc-1a76-4fde-8dd3-3b2057dd9005: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 411bf069-7529-4331-9aeb-537c8aaff705: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 406b764c-cbee-4d8e-b9e1-23dc15a65a6c: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 3fe70008-9840-412a-b177-eb2f6a7341ee: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 3fd9ab01-33b1-424c-a5d6-2be3263db299: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 3f4737b4-c4ac-4f05-832d-8272912bf9c6: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 3e816263-c34e-44d6-b0f2-565bf531204e: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 3e21182d-aa19-4be1-b697-8b2d05c55faf: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 3c4ce7ba-2479-4eb8-8778-dba3d4a9e18e: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 39a239c2-eddc-4a8b-834e-74478b0d0219: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 386351b0-9328-4a23-923f-7636d0c256a1: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 379b5d3c-079a-4c65-b742-f38cf6dc7a11: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 375932ef-1bbf-4f8b-8f64-0b5d6c1f95fe: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 36859cbb-6fe8-4ff6-ad30-6c4e9871fc59: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 357a7559-2c9d-416b-abfb-d253285d84ed: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 34f4b409-0364-4227-b97c-2d653a93df00: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 3458dd48-e2da-48e0-8073-f547d75e3dc0: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 33b1860d-53fc-4493-8c8f-922ccfeb1f98: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 33147bd7-bdc1-444d-b388-498db804566e: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 32c9dfef-895c-4d57-a545-4c443f615b89: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 31e8cfa9-6f6f-4c10-a80c-eb1c57f1ad3d: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 3087667c-3319-40af-9eb3-9df26c048d3d: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 2fe363a2-a8f6-42dc-87d3-9031b68883df: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 2eb05573-1c48-448b-b3d9-7043a43d5903: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 2e16f31e-35c6-45ea-b4d2-9618106682c4: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 2da9d85f-57bc-4ce0-969c-44d488e6ae8e: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 2cdd5946-5006-4d0b-a55b-3accfc0bedca: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 2cd7adda-3b70-4985-b01e-281d325a686d: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 2c655076-f533-4bd8-bb85-a9c1e36a5540: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 2c0044f8-215b-4c4a-a499-83ba39d56afb: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 2ac85c60-934b-4612-a18c-4ed950a4a001: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 2ac10045-72a2-485b-82dd-18d07351dfae: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 28bf182a-2ed9-444e-bcf9-f0d2f160efad: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 288ed63e-120e-4032-9c23-14a354945662: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 285b1797-66fe-4c57-8a75-850c6ec0c32d: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 279f9f0d-1953-4a09-8593-0913fd09d6b8: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 26103d5a-20fb-4361-9081-76254d5edf69: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 2589ab30-1e0f-4b54-b2f3-31e38e33b7e1: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 24b3bad7-1f83-4086-84e7-712f793dc31f: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 248dcef2-565f-4078-bf35-ea2daea6b6f0: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 23bddb09-1b0d-4538-9586-e57421b479cc: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 20b6ca73-8a94-43ee-b119-839377e236e6: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 1fac8442-a9ba-45f8-b004-3bbdcc6bc9c2: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 1f2abfe5-8684-4b49-8ba3-52b58a5aa7d0: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 1ee0058d-01f7-49f3-a47d-00f977da1ab8: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 1c6e3ba1-cf5f-426e-b025-5d15cdfaf3e9: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 1a377626-a60d-4ce4-89c0-f69278e2bb19: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 1a2ad719-1e8b-4b8d-a45c-0cc4456328d7: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 19a91c92-1a15-4653-bca5-3f12fbd91bf6: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 19567ec2-f4b1-4093-ad09-0e5ecbeb0997: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 16a074af-5e52-4113-9849-dc25a69d8b31: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 15547ae5-936b-4ecb-b1bf-1ca732b1b6ae: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 130fa4dc-b304-46b6-b070-8d03e830d6fa: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 11c0bb3e-e5b0-4123-b5a4-f60df1d5bf8c: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 1160be32-ada1-47df-96dd-ceae759ddbf6: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 10431433-1398-4665-bf71-42850d67ce13: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 10097bde-b26b-483a-b744-f9f3b65ad905: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 0ef76f19-ad98-49e9-bbd8-1dd701673925: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 0e6ffef3-6e14-4f89-becd-be196a0a8816: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 0d6359bb-3abb-45c4-a42f-124608d86e4a: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 0d57822e-792b-4954-b489-55952551c3bb: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 0cfb354b-e306-4e42-a9eb-e4458d852fa1: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 0c5c1d35-675f-4e73-be63-81753a43d3d5: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 0b9817c8-002a-41fb-b033-b1e068480d58: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 0b845065-2ccf-4e8d-aaad-4a8aad894921: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 0b7e4fba-97b6-46e7-ba27-4af0b4b2d184: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 0b22b528-176b-4c3f-877b-d0b5e7624cca: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 0b0d8580-b1bd-473f-a9be-0f34266c3635: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 0983a9b9-5017-4d46-b82f-a1d9237b44de: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 09155a00-fddc-4a94-84f7-e838c42c4590: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 0897018b-92a0-4a1f-85f7-cbc06d5a8120: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 089571c0-a3e5-45af-abc8-bd56c494412f: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 07347ddc-4b99-4de9-86d4-0b678554019f: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 06206fe8-1f51-4635-908c-80c0b4013981: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 05965faa-246a-4be5-ab50-93bb42b36ed1: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 0440433a-8954-4278-897d-1ce2b51434f5: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 038af9ac-97e2-4a50-a5c3-78097c8923dc: [1,False,24T - AMZ - BA]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: fe6facd6-b298-4500-92a3-c5e80462ff57: [1,False,1H - UK MAIN]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: fe594e94-3f9b-4548-a068-c7265499974c: [1,False,1H - UK MAIN]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: f98ae12e-0708-4679-b6f4-0264c083eb8a: [1,False,1H - UK MAIN]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: f8911848-5504-4fab-b30e-f4f64b6eacbc: [1,False,1H - UK MAIN]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: f4aff615-e551-4576-a48a-31a9b78661b9: [1,False,1H - UK MAIN]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: f4200f12-9b91-4d9d-b89d-7964a1ba1905: [1,False,1H - UK MAIN]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: f18f5790-8062-4a9c-8154-f2c0b82ef153: [1,False,1H - UK MAIN]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: f0850dfe-0ba5-401c-86b2-3f9957762d1a: [1,False,1H - UK MAIN]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: efcdf7cf-9ada-4578-acea-0ba33f849b88: [1,False,1H - UK MAIN]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: ee60d1d0-febf-4b1c-9d61-6289ffd79b3a: [1,False,1H - UK MAIN]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: ed5851c1-8646-40d4-88f4-7ada52d1812a: [1,False,1H - UK MAIN]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: e99da648-7a8f-4b09-a2ad-916a08b1a285: [1,False,1H - UK MAIN]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: e96f656b-b118-45a0-ac63-f45522a505e0: [1,False,1H - UK MAIN]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: e7c2f830-7197-4e57-a5df-30f751549aa6: [1,False,1H - UK MAIN]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: e4319132-a8d3-42c0-8e04-5059da11cc3f: [1,False,1H - UK MAIN]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: e3cd8e47-afa1-41dd-ba4e-7f12f975a924: [1,False,1H - UK MAIN]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: e1adddb4-fa30-494d-abe5-45866333932d: [1,False,1H - UK MAIN]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: d9b44ba7-dfd8-4a3f-bf2a-222cc8aba6f8: [1,False,1H - UK MAIN]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: d6ba4ee3-2ffd-478a-8241-ef4afb7a33f6: [1,False,1H - UK MAIN]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: d55be62c-132a-4b85-83ca-12bce8f485f9: [1,False,1H - UK MAIN]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: d34ced92-7b25-4e11-b637-d05073900b0c: [1,False,1H - UK MAIN]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: d22b3e63-11f0-45bb-8099-e68227fce800: [1,False,1H - UK MAIN]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: d1b257db-9897-48a6-a65c-ef21f1cfc35d: [1,False,1H - UK MAIN]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: d170ab2b-361f-4189-8bc0-7f9c4617613a: [1,False,1H - UK MAIN]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: cae256a0-c70e-411d-87f2-57d99fc634fa: [1,False,1H - UK MAIN]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: ca897579-ad1d-47ee-8b47-e7ba16075473: [1,False,1H - UK MAIN]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: c5599b83-4d5b-4f1e-bcd1-516d954cc9ef: [1,False,1H - UK MAIN]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: c4e7d6fa-7cac-4b53-9998-6f683cb4c652: [1,False,1H - UK MAIN]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: c286401b-8b74-4551-94e2-263d1bc23233: [1,False,1H - UK MAIN]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: be3ee8fe-476e-438b-a001-23465fd7421c: [1,False,1H - UK MAIN]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: b59c9252-83da-4f35-a934-c5fc29368b52: [1,False,1H - UK MAIN]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: b0eed975-9d33-4eb6-a29f-ee809d23d0f4: [1,False,1H - UK MAIN]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: b09df7b2-6ead-4a6a-b6cf-1131345fbd71: [1,False,1H - UK MAIN]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: b02e16d9-9d98-4b4a-b5f6-38b4d8b25251: [1,False,1H - UK MAIN]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: af34560c-0a07-472c-8a60-3ab00c9bd0ff: [1,False,1H - UK MAIN]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: aed6d31d-59fc-4e6b-84e6-c9ea99864461: [1,False,1H - UK MAIN]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: ac1d313d-e152-4eca-a8e9-ce71591cc509: [1,False,1H - UK MAIN]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: ab1edcfa-bf5a-4437-861b-afd2ea83a5a3: [1,False,1H - UK MAIN]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: a66d7ec3-1265-419a-9453-e9de8d06df4a: [1,False,1H - UK MAIN]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: a4f5e22e-9c62-4770-a2be-a273bf47836a: [1,False,1H - UK MAIN]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: a30bc047-7753-44f6-a483-6293dffa2c98: [1,False,1H - UK MAIN]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: a2d8409d-3cdb-4172-bc0f-83812231162f: [1,False,1H - UK MAIN]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: a18d7265-f2ff-4b51-980d-a3376eca87a0: [1,False,1H - UK MAIN]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 9c53241b-48a2-46fe-a6ce-725fcbf4f290: [1,False,1H - UK MAIN]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 9ad379f6-eb9c-4301-964a-30ada666c7ce: [1,False,1H - UK MAIN]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 988c6b5d-20dd-438f-9e2a-a88b35172c52: [1,False,1H - UK MAIN]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 935ae291-236c-4422-8467-167ee8e47d20: [1,False,1H - UK MAIN]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 90803f07-dc72-43e7-9c1a-8b6676acfa0d: [1,False,1H - UK MAIN]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 8e3424f1-02d3-48ad-a2d4-646e03df8f6f: [1,False,1H - UK MAIN]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 8b9397d1-c4ed-4870-abd9-0a328d3dc68f: [1,False,1H - UK MAIN]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 89d2027e-ba9e-48cf-b735-cc987f01c50d: [1,False,1H - UK MAIN]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 88f25ddf-4549-43a1-8ebe-eb2cca7e7c1c: [1,False,1H - UK MAIN]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 87b7474b-a69b-411e-a07d-d6deb28b22d1: [1,False,1H - UK MAIN]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 86d20b59-416b-4c0d-a190-8c4787b8c57f: [1,False,1H - UK MAIN]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 866e3904-3a78-416a-a5f5-d1dca2578f3a: [1,False,1H - UK MAIN]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 86411305-d759-418e-9adc-bebca5dc7e37: [1,False,1H - UK MAIN]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 85710582-02a5-4e47-b2bd-4f2d9e198934: [1,False,1H - UK MAIN]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 8510aefa-5a12-42f4-b559-b96db6d7c0d4: [1,False,1H - UK MAIN]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 833196db-165c-4c70-b532-4e6d1da969fb: [1,False,1H - UK MAIN]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 7f45a813-b963-4939-a4fa-679f110dde82: [1,False,1H - UK MAIN]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 7ef1f6b0-0ebf-4bf8-b9e7-e1496712c4bc: [1,False,1H - UK MAIN]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 7ebb1675-3dd9-4b50-a877-02c054b7f2c3: [1,False,1H - UK MAIN]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 7b1d07f0-8085-4116-a2fd-793b4732ad1a: [1,False,1H - UK MAIN]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 797ef2ca-4101-4c56-8640-573ba3e6610c: [1,False,1H - UK MAIN]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 7930ac70-6ad0-443e-9511-9917431c7c59: [1,False,1H - UK MAIN]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 787e367a-8235-4e70-b5e3-f55ddefa2048: [1,False,1H - UK MAIN]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 771badc3-b50e-4a88-8c25-cc4ffc362128: [1,False,1H - UK MAIN]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 77056200-c4e9-440b-b019-fdb8b06f3a69: [1,False,1H - UK MAIN]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 76e88698-e236-4091-90dc-f93403ef87bb: [1,False,1H - UK MAIN]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 748db09e-cdff-4cd7-b0b8-2cb51176ad5e: [1,False,1H - UK MAIN]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 74158be0-a6e5-4b69-9dd7-0aaaae9ad95b: [1,False,1H - UK MAIN]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 73c06962-7ff1-4afb-aded-fb700b5a6b3e: [1,False,1H - UK MAIN]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 7143d923-5a55-49da-8c84-3b35bf81c9c5: [1,False,1H - UK MAIN]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 6f715555-d1e8-4242-a45f-cb48e83a8afd: [1,False,1H - UK MAIN]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 6dd3737c-4f47-41ca-b825-38c27a4b9e6c: [1,False,1H - UK MAIN]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 6ce625ee-6777-48ae-8181-132cc30e5de1: [1,False,1H - UK MAIN]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 6cab6c52-485a-4dc8-8411-a00d22bac454: [1,False,1H - UK MAIN]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 69cf26e1-ef42-4d77-8c12-4e4062b1711e: [1,False,1H - UK MAIN]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 6975d291-c092-45c8-95a3-b9dfbc02f030: [1,False,1H - UK MAIN]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 668b7268-e3b3-413e-a2bd-8d1e1455bf7f: [1,False,1H - UK MAIN]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 65e5f024-fed3-404b-8cb1-3e1b44cb5141: [1,False,1H - UK MAIN]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 6453143b-497a-4800-a443-565e56011d35: [1,False,1H - UK MAIN]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 63ad1442-500f-4a89-8efb-46521be65ffa: [1,False,1H - UK MAIN]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 6217b46c-167e-4275-a860-d728a025d1a7: [1,False,1H - UK MAIN]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 62130ae7-c188-4c68-b5ad-7e862e475185: [1,False,1H - UK MAIN]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 60670a39-6c14-4e3a-9775-97b9b1b1c79e: [1,False,1H - UK MAIN]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 5e9d20be-3fec-4d63-b12d-52128c8188a6: [1,False,1H - UK MAIN]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 5d00e25a-6c98-4dd1-8a2d-948d13361a4d: [1,False,1H - UK MAIN]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 5752e0d4-d608-4087-8182-44ae28f27eaf: [1,False,1H - UK MAIN]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 55705a0d-2b71-4aef-b947-d3994c6bd878: [1,False,1H - UK MAIN]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 551b1561-7d05-4bbc-a8ed-f15445f02dda: [1,False,1H - UK MAIN]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 54970c73-f0a0-49ad-9905-bb9a62ff02e1: [1,False,1H - UK MAIN]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 5195091e-4dc7-4ff7-9223-6302bb4c56c7: [1,False,1H - UK MAIN]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 51453c3d-a782-45b9-bdd6-054ed4e4dbe1: [1,False,1H - UK MAIN]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 513de93d-a3e9-4eba-bdf4-e327afba0015: [1,False,1H - UK MAIN]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 4fc42641-2c13-4d28-b258-a0f78f247762: [1,False,1H - UK MAIN]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 4e7121c8-ba53-4ce8-a6e9-c18fee0a957c: [1,False,1H - UK MAIN]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 4e399198-b715-430f-a886-51f1cbf8a841: [1,False,1H - UK MAIN]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 4cadb38e-5340-4257-bb46-b079c5f340d7: [1,False,1H - UK MAIN]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 4c130024-ec5a-4b9f-ad63-3ee1352cdece: [1,False,1H - UK MAIN]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 4a22a8b8-9ddb-4b97-b424-cbd225c0fbcb: [1,False,1H - UK MAIN]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 49cb64b3-3757-409b-b0cb-38560ba787d7: [1,False,1H - UK MAIN]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 460bb83b-491d-4de3-b436-807e62ab79f6: [1,False,1H - UK MAIN]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 450101ce-6ba9-4b77-a61f-fa38bade6331: [1,False,1H - UK MAIN]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 441e7fe5-4664-4816-a129-e17d92d048db: [1,False,1H - UK MAIN]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 4367a8da-cb39-4528-8f0c-8fdf22934b98: [1,False,1H - UK MAIN]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 4024693f-0f49-4c86-bcbc-7a3f5549009d: [1,False,1H - UK MAIN]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 3fe4a51e-6124-401c-9424-333b89985a8c: [1,False,1H - UK MAIN]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 3a18337f-bda7-4466-9458-49b524ab97d3: [1,False,1H - UK MAIN]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 39a42cad-9cb1-4b26-b434-cd4b5f203990: [1,False,1H - UK MAIN]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 36d6e556-3d50-465a-95fd-497a01d19e2a: [1,False,1H - UK MAIN]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 34f180c9-f054-4c20-af13-1531bb6457ff: [1,False,1H - UK MAIN]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 340e4120-59dd-461d-a26f-840ef5c6850a: [1,False,1H - UK MAIN]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 33653de0-c047-44ec-a8ce-554ba3c9d255: [1,False,1H - UK MAIN]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 32c4ba11-910d-424a-9b94-cb23bc328d70: [1,False,1H - UK MAIN]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 31f34478-0801-47c2-aab5-034e946619f8: [1,False,1H - UK MAIN]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 2f9ec3e0-88cf-4617-bca8-0d75d4226e34: [1,False,1H - UK MAIN]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 2d66ca09-5b14-45c1-b2c4-c1fa0f5745c5: [1,False,1H - UK MAIN]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 2d25fcd4-ede6-4a29-a985-af14efe995d9: [1,False,1H - UK MAIN]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 2d0921bd-e2ca-40cd-8643-28fd9057ad58: [1,False,1H - UK MAIN]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 2d000e4f-865a-4dc2-aee5-1e6b39e0cebd: [1,False,1H - UK MAIN]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 2ccdc8eb-5305-4d6d-a58b-b942bfa149e0: [1,False,1H - UK MAIN]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 2cbc9eee-a359-4d29-a6ca-a99cded590ca: [1,False,1H - UK MAIN]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 2c1c7e67-af72-44fe-8240-3e603536171d: [1,False,1H - UK MAIN]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 2aac8d1d-d514-4469-b8cf-c9c03b76a3fd: [1,False,1H - UK MAIN]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 2a606307-f26f-4fc3-8684-706916031656: [1,False,1H - UK MAIN]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 25c5bf7e-affe-42f8-a4e2-f1d4edd37216: [1,False,1H - UK MAIN]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 22ac94e2-28e2-4a37-a28b-1a64c38db2c6: [1,False,1H - UK MAIN]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 20fe4553-416e-4a99-92f7-d583bb2b862f: [1,False,1H - UK MAIN]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 18160013-90a9-4bae-a3e2-08d09a77ac9d: [1,False,1H - UK MAIN]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 17f82642-46bc-4caf-bac7-7645863e3cad: [1,False,1H - UK MAIN]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 17929f27-30cb-485e-b5b1-aa9fbc704122: [1,False,1H - UK MAIN]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 14c85aa2-83bf-4987-aa00-741acf91c549: [1,False,1H - UK MAIN]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 148c84d8-241a-4456-8b51-aaebf0e36915: [1,False,1H - UK MAIN]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 13ac1958-21db-4377-8cfb-45a3dc4bff9d: [1,False,1H - UK MAIN]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 12cd7079-83e4-421c-8264-83dba2d3bdfd: [1,False,1H - UK MAIN]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 12be5088-5bae-4732-b94a-9fcbe5a26828: [1,False,1H - UK MAIN]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 123f9650-3d06-4815-894f-a141ca690f2b: [1,False,1H - UK MAIN]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 0fcad0df-2db3-44cb-85f7-d52c2f12679f: [1,False,1H - UK MAIN]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 0ca7cb91-3f00-4fae-84b4-71d37726ace3: [1,False,1H - UK MAIN]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 0bee2430-00d6-41ba-a814-21556cfd2290: [1,False,1H - UK MAIN]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 08457485-e7c3-472f-b2cb-d3d4dc1f8c8c: [1,False,1H - UK MAIN]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 0585b364-aa01-4b00-badf-a0720d1b83c1: [1,False,1H - UK MAIN]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 04d783d2-faa0-4721-92de-dc3a3b26dd35: [1,False,1H - UK MAIN]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 04cc826d-00cb-47e7-a5de-5017fb2637a5: [1,False,1H - UK MAIN]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 036958d5-1780-4c90-89b9-c5350d69c2f6: [1,False,1H - UK MAIN]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: f523fa94-a1d1-4aa7-aeb0-0500ef6dbe76: [1,False,1H - ROI 72]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: cc25ae86-2f23-4ce5-b4bd-4cef600d5b62: [1,False,1H - ROI 72]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 9937da0c-b878-4ba1-b0de-0eb3b141e0f3: [1,False,1H - ROI 72]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 820a9125-2b1e-4354-9fc1-1e6f14786023: [1,False,1H - ROI 72]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 79e1cf25-85cc-4d12-a524-7e5e042a899e: [1,False,1H - ROI 72]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 68008bf3-01d4-4543-8499-bfe23592dcdb: [1,False,1H - ROI 72]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: a92b05bd-556c-4404-9fb4-307da22780c0: [1,False,1H - JE/GY]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 9a33a883-ddfd-4157-baff-2d6a71d72b29: [1,False,1H - ISLE]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 95dad1c9-bd58-464e-a03a-d9c033a00a0e: [1,False,1H - ISLE]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: 582c4a2f-8eba-4e35-8bad-dabdb7fd89ef: [1,False,1H - ISLE]
result: -1
a: 07b86c1f-251c-4ddf-b626-2532e90de4eb: [1,False,1H - UK MAIN]
b: b160051e-b299-4683-9850-53c45b6ed153: [1,False,1H - BT]
result: -1";


        readonly Dictionary<Guid, string> _orders = new();
        private string[] GetLines()
        {
            var lines = _input.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            Regex r = new(@": ([\w-]+): \[([\w,\- \/:]+)\]");

            foreach(var line in lines)
            {
                if (line.StartsWith("result:")) continue;
                Match match = r.Match(line);

                Guid id = new(match.Groups[1].ToString());
                if (!_orders.ContainsKey(id))
                {
                    _orders.Add(id, match.Groups[2].ToString());
                }
            }

            r = new Regex(@"(\d),(False|True),([\w,\- \/:]+)");
            StringBuilder sb = new();
            sb.AppendLine("var orders = OrdersWithKeys(");
            foreach(var order in _orders)
            {
                sb.AppendLine("new Dictionary<byte, object>{");
                Match lineSplit = r.Match(order.Value);
                for(int i = 1; i < lineSplit.Groups.Count; i++)
                {
                    var m = lineSplit.Groups[i];
                    bool isThree = i == lineSplit.Groups.Count - 1;
                    sb.AppendLine($"{{ {i},  {(isThree ? "\"" : "")}{m}{(isThree ? "\"" : "")} }}{(isThree ? "" : ",")}");
                }
                sb.AppendLine("},");
            }
            sb.AppendLine(");");

            return lines;
        }
       
        private void GetValues()
        {
            _ = GetLines();
        }

        public string Task1()
        {
            GetValues();
            return "";
        }

        public string Task2() => Task1();
    }
}
