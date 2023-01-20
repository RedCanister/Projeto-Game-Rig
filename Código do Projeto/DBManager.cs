using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DBManager
{
    // Definindo o nome do arquivo, usar um novo para cada perfil.
    // Colocar todos os arquivos de perfil em uma lista

    // Modelo | Velocidade | Socket | Watts | Preço
    private static List<string> cpu_13600k = new List<string>{"Intel Core i5 13600K", "5.1 GHZ", "LGA 1700", "181W", "2970"};
    private static List<string> cpu_12400 = new List<string>{"Intel Core i5 12400", "4.4 GHZ", "LGA1700", "65W", "1659"};
    private static List<string> cpu_13900k = new List<string>{"Intel Core i9 13900K", "5.8 GHZ", "LGA1700", "125W", "4599"};

    // CPU Socket AM5
    private static List<string> cpu_7700X = new List<string>{"AMD Ryzen 7 7700X", "5.4 GHZ", "AM5", "105W", "3045"};
    private static List<string> cpu_7950X = new List<string>{"AMD Ryzen 9 7950X", "5.7 GHZ", "AM5", "170W", "5266"};

    // CPU Socket AM4
    private static List<string> cpu_5800X3D = new List<string>{"AMD Ryzen 7 5800X3D", "4.5 GHZ", "AM4", "105W", "2122"};
    private static List<string> cpu_5700G = new List<string>{"AMD Ryzen 7 5700G", "4.6 GHZ", "AM4", "65W", "1500"};

    // Chipset | Socket | DDR | HDDs | SSDs | Preço
    private static List<string> mb_B660M = new List<string>{"Gigabyte B660M DS3H", "LGA 1700", "DDR4", "4", "2", "1150"};
    private static List<string> mb_X570 = new List<string>{"Asus Prime X570-Pro", "AM4", "DDR4", "6", "2", "2177"};
    private static List<string> mb_X670E = new List<string>{"Asus TUF Gaming X670E-Plus", "AM5", "DDR5", "4", "4", "3221"};

    // Modelo | Capacidade | GDDR | Watts | Preço
    private static List<string> gpu_4090 = new List<string>{"RTX 4090", "24GB", "GDDR6X", "450W", "16410"}; //850W
    private static List<string> gpu_3060 = new List<string>{"RTX 3060Ti", "8GB", "GDDR6", "200W", "3354"}; //650W
    private static List<string> gpu_6800 = new List<string>{"RX 6800 XT", "16GB", "GDDR6", "300W", "7516"}; //750W
    private static List<string> gpu_6650 = new List<string>{"RX 6650 XT", "8GB", "GDDR6", "180W", "2732"}; //500W

    // Modelo | Capacidade | Velocidade | DDR | Preço
    private static List<string> ram_GSZ5 = new List<string>{"G.Skill Trident Z5 RGB", "2x16GB", "6000", "DDR5", "4200"};
    private static List<string> ram_TGTX = new List<string>{"T-Force Xtreem ARGB", "2x16GB", "3600", "DDR4", "1079"};
    private static List<string> ram_VENG = new List<string>{"Corsair Vengeance", "2x32GB", "5200", "DDR5", "2618"};
    private static List<string> ram_D45G = new List<string>{"XPG Spectrix D45G", "2x32GB", "3600", "DDR4", "2472"};

    // Modelo | Watts | Modular | Preço
    private static List<string> ps_RM750x = new List<string>{"Corsair RM750x", "750W", "Modular", "1454"};
    private static List<string> ps_TX1000 = new List<string>{"Seasonic Prime Titanium TX-1000", "1000W", "Modular", "3650"};

    // Modelo | Capacidade | Slot | Preço
    private static List<string> ssd_SN770 = new List<string>{"SSD 250GB WD Black SN770", "250GB", "M.2", "400"};
    private static List<string> ssd_KNV2 = new List<string>{"SSD 1TB Kingston NV2", "1TB", "M.2", "700"};
    private static List<string> hdd_SG4T = new List<string>{"HD Seagate 4TB BarraCuda", "4TB", "Sata", "588"};
    private static List<string> hdd_SG2T = new List<string>{"HD Seagate 2TB BarraCuda", "4TB", "Sata", "435"};

    public static List<List<string>> cpu_list_1700 = new List<List<string>>(){
        cpu_13600k, cpu_12400, cpu_13900k
    };

    public static List<List<string>> cpu_list_AM5 = new List<List<string>>(){
        cpu_7700X, cpu_7950X
    };

    public static List<List<string>> cpu_list_AM4 = new List<List<string>>(){
        cpu_5800X3D, cpu_5700G
    };

    public static List<List<string>> mb_list = new List<List<string>>(){
        mb_B660M, mb_X570, mb_X670E
    };

    public static List<List<string>> gpu_list = new List<List<string>>(){
        gpu_4090, gpu_3060, gpu_6800, gpu_6650
    };

    public static List<List<string>> ram_list_DDR5 = new List<List<string>>(){
        ram_GSZ5, ram_VENG
    };

    public static List<List<string>> ram_list_DDR4 = new List<List<string>>(){
        ram_TGTX, ram_D45G
    };

    public static List<List<string>> ps_list = new List<List<string>>(){
        ps_RM750x, ps_TX1000
    };

    public static List<List<string>> SSD_list = new List<List<string>>(){
        ssd_SN770, ssd_KNV2
    };

    public static List<List<string>> HDD_list = new List<List<string>>(){
        hdd_SG4T, hdd_SG2T
    };

}