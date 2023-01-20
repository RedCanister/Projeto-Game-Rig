using System.Collections.Generic;
using System.Collections;
using static DBManager;
using UnityEngine.UI;
using UnityEngine;
using System.IO;
using System;
using TMPro;

public class DropdownManager : MonoBehaviour
{
    public GameObject Motherboard, CPU, GPU, Fonte, RAM, SSD, HDD, Perfil;

    [HideInInspector] public TMP_Dropdown mb_DD, cpu_DD, gpu_DD, fonte_DD, ram_DD, HDD_DD, SSD_DD, perfil_DD;

    private GameObject img_placa, img_cpu, img_gpu, img_fonte, img_ram, img_SSD, img_HDD;
    private TMP_Text label_placa, label_cpu, label_gpu, label_fonte, label_ram, label_SSD, label_HDD;
    private TMP_Text body_placa, body_cpu, body_gpu, body_fonte, body_ram, body_SSD, body_HDD;
    private TMP_Text label_perfil, label_preco;

    private Text SSD_Btn, HDD_Btn;

    private string _placa_mae, _cpu, _gpu, _fonte, _ram, _SSD, _HDD;
    private int _perfil;

    byte[] bytes;
    private Texture2D img_texture;
    private Texture2D img_sprite;

    private bool change_ram, change_cpu = true;

    private string _DDR, _socket, _potencia, _cpu_GHZ, _ram_GB, _gpu_GB, _gpu_GDDR, _hdd_TB, _ssd_TB;
    private int HDD_Slots, SSD_Slots;
    private int HDD_Total, SSD_Total;
    private int _preco_mb, _preco_cpu, _preco_gpu, _preco_fonte, _preco_ram, _preco_SSD, _preco_HDD, _preco_total;

    // Start is called before the first frame update
    void Start()
    {
        // Inicializando as variáveis das listas
        mb_DD = Motherboard.GetComponentInChildren<TMP_Dropdown>();
        cpu_DD = CPU.GetComponentInChildren<TMP_Dropdown>();
        gpu_DD = GPU.GetComponentInChildren<TMP_Dropdown>();
        fonte_DD = Fonte.GetComponentInChildren<TMP_Dropdown>();
        ram_DD = RAM.GetComponentInChildren<TMP_Dropdown>();
        SSD_DD = SSD.GetComponentInChildren<TMP_Dropdown>();
        HDD_DD = HDD.GetComponentInChildren<TMP_Dropdown>();
        perfil_DD = Perfil.GetComponentInChildren<TMP_Dropdown>();

        SSD_Btn = GameObject.Find("Btn SSD").GetComponentInChildren<Text>();
        HDD_Btn = GameObject.Find("Btn HDD").GetComponentInChildren<Text>(); 

        img_placa = GameObject.Find("/Gallery/Canvas/img_placa");
        img_cpu = GameObject.Find("/Gallery/Canvas/img_cpu");
        img_gpu = GameObject.Find("/Gallery/Canvas/img_gpu");
        img_fonte = GameObject.Find("/Gallery/Canvas/img_fonte");
        img_ram = GameObject.Find("/Gallery/Canvas/img_ram");
        img_SSD = GameObject.Find("/Gallery/Canvas/img_SSD");
        img_HDD = GameObject.Find("/Gallery/Canvas/img_HDD");

        //bytes = File.ReadAllBytes(@"C:\Users\Jorge\Documents\Projeto Game Rig\Projeto Game Rig\Assets\Images\Hardware\b660m-ds3h.jpg");
        //img_texture.LoadRawTextureData(bytes);
        //img_texture.Apply();
        
        //img_texture = Resources.Load<Texture>(bytes);
        //img_texture = Resources.Load<Texture2D>("Images/Hardware/b660m-ds3h.jpg") as Texture2D;
        //img_sprite.texture = Resources.Load<Texture2D>("Images/Hardware/b660m-ds3h.jpg");
        //img_sprite.texture = img_texture;

        //img_placa.GetComponent<Image>().sprite = img_sprite;
        //img_placa.GetComponent<Image>().sprite = img_sprite;

        //Debug.Log(img_texture.name);

        label_placa = GameObject.Find("/Gallery/Canvas/img_placa/label_placa").GetComponent<TMPro.TMP_Text>();
        label_cpu = GameObject.Find("/Gallery/Canvas/img_cpu/label_cpu").GetComponent<TMPro.TMP_Text>();
        label_gpu = GameObject.Find("/Gallery/Canvas/img_gpu/label_gpu").GetComponent<TMPro.TMP_Text>();
        label_fonte = GameObject.Find("/Gallery/Canvas/img_fonte/label_fonte").GetComponent<TMPro.TMP_Text>();
        label_ram = GameObject.Find("/Gallery/Canvas/img_ram/label_ram").GetComponent<TMPro.TMP_Text>();
        label_SSD = GameObject.Find("/Gallery/Canvas/img_SSD/label_SSD").GetComponent<TMPro.TMP_Text>();
        label_HDD = GameObject.Find("/Gallery/Canvas/img_HDD/label_HDD").GetComponent<TMPro.TMP_Text>();

        body_placa = GameObject.Find("/Gallery/Canvas/img_placa/body_placa").GetComponent<TMPro.TMP_Text>();
        body_cpu = GameObject.Find("/Gallery/Canvas/img_cpu/body_cpu").GetComponent<TMPro.TMP_Text>();
        body_gpu = GameObject.Find("/Gallery/Canvas/img_gpu/body_gpu").GetComponent<TMPro.TMP_Text>();
        body_fonte = GameObject.Find("/Gallery/Canvas/img_fonte/body_fonte").GetComponent<TMPro.TMP_Text>();
        body_ram = GameObject.Find("/Gallery/Canvas/img_ram/body_ram").GetComponent<TMPro.TMP_Text>();
        body_SSD = GameObject.Find("/Gallery/Canvas/img_SSD/body_SSD").GetComponent<TMPro.TMP_Text>();
        body_HDD = GameObject.Find("/Gallery/Canvas/img_HDD/body_HDD").GetComponent<TMPro.TMP_Text>();

        label_preco = GameObject.Find("/Gallery/Canvas/Preço").GetComponent<TMPro.TMP_Text>();
        label_perfil = GameObject.Find("/Gallery/Canvas/Perfil").GetComponent<TMPro.TMP_Text>();

        //MB List creation
        UpdateDropdownOptions(mb_DD, new List<String>{"Placa-mãe"});
        for(int i = 0; i < mb_list.Count; i++){
            AddDropdownOptions(mb_DD, 
                new List<String>{DBManager.mb_list[i][0]});
        }

        //CPU List creation
        UpdateDropdownOptions(cpu_DD, new List<String>{"CPU"});

        //GPU List creation
        UpdateDropdownOptions(gpu_DD, new List<String>{"GPU"});
        for(int i = 0; i < gpu_list.Count; i++){
            AddDropdownOptions(gpu_DD, 
                new List<String>{DBManager.gpu_list[i][0]});
        }

        //RAM List creation
        UpdateDropdownOptions(ram_DD, new List<String>{"RAM"});

        //PW List creation
        UpdateDropdownOptions(fonte_DD, new List<String>{"Fonte"});        
        for(int i = 0; i < ps_list.Count; i++){
            AddDropdownOptions(fonte_DD, 
                new List<String>{DBManager.ps_list[i][0]});
        }

        //STRG List creation
        UpdateDropdownOptions(SSD_DD, new List<String>{"SSD"});
        for(int i = 0; i < SSD_list.Count; i++){
            AddDropdownOptions(SSD_DD, 
                new List<String>{DBManager.SSD_list[i][0]});
        }

        UpdateDropdownOptions(HDD_DD, new List<String>{"HDD"});
        for(int i = 0; i < HDD_list.Count; i++){
            AddDropdownOptions(HDD_DD, 
                new List<String>{DBManager.HDD_list[i][0]});
        }

        //Perfil list creation
        perfil_DD.ClearOptions();
        AddDropdownOptions(perfil_DD, new List<String>{
            "Perfil 1", // 0
            "Perfil 2", // 1
            "Perfil 3", // 2
            "Perfil 4", // 3
            "Perfil 5" // 4
        });

        CarregarPerfil();

    }

    // Update is called once per frame
    void Update()
    {
        mb_DD.onValueChanged.AddListener(delegate {
            change_cpu = true;
            change_ram = true;
        });

        // Registro de dados da placa-mãe
        for(int i = 1; i <= mb_list.Count; i++){
            if(i == mb_DD.value){
                _placa_mae = DBManager.mb_list[i-1][0];
                _socket = DBManager.mb_list[i-1][1];
                _DDR = DBManager.mb_list[i-1][2];
                HDD_Slots = Int32.Parse(DBManager.mb_list[i-1][3]);
                SSD_Slots = Int32.Parse(DBManager.mb_list[i-1][4]);
                _preco_mb = Int32.Parse(DBManager.mb_list[i-1][5]);
            }else if(i == 0){
                _placa_mae = "";
                _socket = "";
                HDD_Slots = 0;
                SSD_Slots = 0;
                _preco_mb = 0;

            }
        }
    /*----------------------------------------------------*/

        // Registro de dados de processadores

        if(_socket == "LGA 1700" ){ // LGA 1700 DBManager.mb_list[0][2]
            if(change_cpu){
                UpdateDropdownOptions(cpu_DD, new List<String>{"CPU"});
                for(int i = 0; i < cpu_list_1700.Count; i++){
                    AddDropdownOptions(cpu_DD, 
                        new List<String>{DBManager.cpu_list_1700[i][0]});
                }
                change_cpu = false;
            }

            for(int i = 1; i <= cpu_list_1700.Count; i++){
                if(i == cpu_DD.value){
                    _cpu = DBManager.cpu_list_1700[i-1][0];
                    _cpu_GHZ = DBManager.cpu_list_1700[i-1][1];
                    _preco_cpu = Int32.Parse(DBManager.cpu_list_1700[i-1][4]);
                }else if(i == 0){
                    _cpu = "";
                    _cpu_GHZ = "";
                    _preco_cpu = 0;
                }
            }

        }
        

        if(_socket == "AM4" ){ // AM4 DBManager.mb_list[1][2]
            if(change_cpu){
                UpdateDropdownOptions(cpu_DD, new List<String>{"CPU"});
                for(int i = 0; i < cpu_list_AM4.Count; i++){
                    AddDropdownOptions(cpu_DD, 
                        new List<String>{DBManager.cpu_list_AM4[i][0]});
                }
                change_cpu = false;
            }

            for(int i = 1; i <= cpu_list_AM4.Count; i++){
                if(i == cpu_DD.value){
                    _cpu = DBManager.cpu_list_AM4[i-1][0];
                    _cpu_GHZ = DBManager.cpu_list_AM4[i-1][1];
                    _preco_cpu = Int32.Parse(DBManager.cpu_list_AM4[i-1][4]);
                }else if(i == 0){
                    _cpu = "";
                    _cpu_GHZ = "";
                    _preco_cpu = 0;
                }
            }

        }
        

        if(_socket == "AM5" ){ // AM5 DBManager.mb_list[2][2]
            if(change_cpu){
                UpdateDropdownOptions(cpu_DD, new List<String>{"CPU"});
                for(int i = 0; i < cpu_list_AM5.Count; i++){
                    AddDropdownOptions(cpu_DD, 
                        new List<String>{DBManager.cpu_list_AM5[i][0]});
                }
                change_cpu = false;
            }

            for(int i = 1; i <= cpu_list_AM5.Count; i++){
                if(i == cpu_DD.value){
                    _cpu = DBManager.cpu_list_AM5[i-1][0];
                    _cpu_GHZ = DBManager.cpu_list_AM5[i-1][1];
                    _preco_cpu = Int32.Parse(DBManager.cpu_list_AM5[i-1][4]);
                }else if(i == 0){
                    _cpu = "";
                    _cpu_GHZ = "";
                    _preco_cpu = 0;
                }
            }

        }
    /*----------------------------------------------------*/

        // Registro de dados de placas de vídeo
        for(int i = 1; i <= gpu_list.Count; i++){
            if(i == gpu_DD.value){
                _gpu = DBManager.gpu_list[i-1][0];
                _gpu_GB = DBManager.gpu_list[i-1][1];
                _gpu_GDDR = DBManager.gpu_list[i-1][2];
                _preco_gpu = Int32.Parse(DBManager.gpu_list[i-1][4]);
            }else if(i == 0){
                _gpu = "";
                _gpu_GB = "";
                _gpu_GDDR = "";
                _preco_gpu = 0;
            }
        }
    /*----------------------------------------------------*/

        // Registro de dados de fontes
        for(int i = 1; i <= ps_list.Count; i++){
            if(i == fonte_DD.value){
                _fonte = DBManager.ps_list[i-1][0];
                _potencia = DBManager.ps_list[i-1][1];
                _preco_fonte = Int32.Parse(DBManager.ps_list[i-1][3]);
            }else if(i == 0){
                _fonte = "";
                _potencia = "";
                _preco_fonte = 0;
            }
        }
    /*----------------------------------------------------*/

        // Registro de dados de memória RAM
        if(_DDR == "DDR4")
        {
            if(change_ram)
            {
                UpdateDropdownOptions(ram_DD, new List<String>{"RAM"});
                for(int i = 0; i < ram_list_DDR4.Count; i++){
                    AddDropdownOptions(ram_DD, 
                        new List<String>{DBManager.ram_list_DDR4[i][0]});
                }
                change_ram = false;
            }

            for(int i = 1; i <= ram_list_DDR4.Count; i++){
                if(i == ram_DD.value){
                    _ram = DBManager.ram_list_DDR4[i-1][0];
                    _ram_GB = DBManager.ram_list_DDR4[i-1][1];
                    _preco_ram = Int32.Parse(DBManager.ram_list_DDR4[i-1][4]);
                }else if(i == 0){
                    _ram = "";
                    _ram_GB = "";
                    _preco_ram = 0;
                }
            }
        }

        if(_DDR == "DDR5")
        {
            if(change_ram)
            {
                UpdateDropdownOptions(ram_DD, new List<String>{"RAM"});
                for(int i = 0; i < ram_list_DDR5.Count; i++){
                    AddDropdownOptions(ram_DD, 
                        new List<String>{DBManager.ram_list_DDR5[i][0]});
                }
                change_ram = false;
            }

            for(int i = 1; i <= ram_list_DDR5.Count; i++){
                if(i == ram_DD.value){
                    _ram = DBManager.ram_list_DDR5[i-1][0];
                    _ram_GB = DBManager.ram_list_DDR5[i-1][1];
                    _preco_ram = Int32.Parse(DBManager.ram_list_DDR5[i-1][4]);
                }else if(i == 0){
                    _ram = "";
                    _ram_GB = "";
                    _preco_ram = 0;
                }
            }
        }
    /*----------------------------------------------------*/

        // Registro de dados de armazenamento

        for(int i = 1; i <= SSD_list.Count; i++){
            if(i == SSD_DD.value){
                _SSD = DBManager.SSD_list[i-1][0];
                _ssd_TB = DBManager.SSD_list[i-1][1];
                _preco_SSD = Int32.Parse(DBManager.SSD_list[i-1][3]);
            }else if(i == 0){
                 _SSD = "";
                 _ssd_TB = "";
                 _preco_SSD = 0;
            }
        }

        for(int i = 1; i <= HDD_list.Count; i++){
            if(i == HDD_DD.value){
                _HDD = DBManager.HDD_list[i-1][0];
                _hdd_TB = DBManager.HDD_list[i-1][1];
                _preco_HDD = Int32.Parse(DBManager.HDD_list[i-1][3]);
            }else if(i == 0){
                 _HDD = "";
                 _hdd_TB = "";
                 _preco_HDD = 0;
            }
        }
    /*----------------------------------------------------*/

        // Registro de dados de perfil
        switch(perfil_DD.value)
        {
            case 0:
                _perfil = 1;
                break;
            case 1:
                _perfil = 2;
                break;
            case 2:
                _perfil = 3;
                break;
            case 3:
                _perfil = 4;
                break;
            case 4:
                _perfil = 5;
                break;
            default:
                break;
        }

        //Atualizando as informações em texto
        label_placa.text = _placa_mae;
        label_cpu.text = _cpu;
        label_gpu.text = _gpu;
        label_fonte.text = _fonte;
        label_ram.text = _ram;
        label_SSD.text = _SSD;
        label_HDD.text = _HDD;

        SSD_Btn.text = SSD_Total.ToString();
        HDD_Btn.text = HDD_Total.ToString();

        label_preco.text = "R$"+(_preco_cpu + _preco_mb + _preco_fonte + _preco_gpu + _preco_ram 
                            + (_preco_SSD*SSD_Total) + (_preco_HDD*HDD_Total)).ToString();
        label_perfil.text = "Perfil "+_perfil.ToString();

        body_placa.text = "Socket:"+_socket+"\n"
                        +_DDR+"\n"
                        +"R$"+_preco_mb.ToString();

        body_cpu.text = "Velocidade: "+_cpu_GHZ+"\n"
                        +"Socket: "+_socket+"\n"
                        +"R$"+_preco_cpu;

        body_gpu.text = "Capacidade: "+_gpu_GB+"\n"
                        +_gpu_GDDR+"\n"
                        +"R$"+_preco_gpu;

        body_fonte.text = "Potência: "+_potencia+"\n"
                        +"R$"+_preco_fonte;

        body_ram.text = "Capacidade: "+_ram_GB+"\n"
                        +_DDR+"\n"
                        +"R$"+_preco_ram;

        body_SSD.text = "Quantidade: "+SSD_Total+"\n"
                        +"Capacidade: "+_ssd_TB+"\n"
                        +"R$"+_preco_SSD;
        body_HDD.text = "Quantidade: "+HDD_Total+"\n"
                        +"Capacidade: "+_hdd_TB+"\n"
                        +"R$"+_preco_HDD;

    }

    // MÉTODOS
    public void SalvarPerfil()
    {    
        PlayerPrefs.SetInt("Perfil"+_perfil+"MB", mb_DD.value);
        
        if(_socket == "LGA 1700")
            PlayerPrefs.SetInt("Perfil"+_perfil+"CPU", cpu_DD.value);
        if(_socket == "AM5")
            PlayerPrefs.SetInt("Perfil"+_perfil+"CPU", cpu_DD.value);
        if(_socket == "AM4")
            PlayerPrefs.SetInt("Perfil"+_perfil+"CPU", cpu_DD.value);

        PlayerPrefs.SetInt("Perfil"+_perfil+"GPU", gpu_DD.value);
        PlayerPrefs.SetInt("Perfil"+_perfil+"PW", fonte_DD.value);

        if(_DDR == "DDR4")
            PlayerPrefs.SetInt("Perfil"+_perfil+"RAM", ram_DD.value);
        if(_DDR == "DDR5")
            PlayerPrefs.SetInt("Perfil"+_perfil+"RAM", ram_DD.value);
        
        PlayerPrefs.SetInt("Perfil"+_perfil+"SSD", SSD_DD.value);
        PlayerPrefs.SetInt("Perfil"+_perfil+"HDD", HDD_DD.value);

        PlayerPrefs.SetInt("Perfil"+_perfil+"SSD_Total", SSD_Total);
        PlayerPrefs.SetInt("Perfil"+_perfil+"HDD_Total", HDD_Total);
        PlayerPrefs.Save();
    }

    public void CarregarPerfil()
    {    
        mb_DD.value = PlayerPrefs.GetInt("Perfil"+_perfil+"MB", 0);
        cpu_DD.value = PlayerPrefs.GetInt("Perfil"+_perfil+"CPU", 0);
        gpu_DD.value = PlayerPrefs.GetInt("Perfil"+_perfil+"GPU", 0);
        fonte_DD.value = PlayerPrefs.GetInt("Perfil"+_perfil+"PW", 0);
        ram_DD.value = PlayerPrefs.GetInt("Perfil"+_perfil+"RAM", 0);
        SSD_DD.value = PlayerPrefs.GetInt("Perfil"+_perfil+"SSD", 0);
        HDD_DD.value = PlayerPrefs.GetInt("Perfil"+_perfil+"HDD", 0);

        SSD_Total = PlayerPrefs.GetInt("Perfil"+_perfil+"SSD_Total", 0);
        HDD_Total = PlayerPrefs.GetInt("Perfil"+_perfil+"HDD_Total", 0);
    }

    void UpdateDropdownOptions(TMP_Dropdown dropdown, List<string> options)
    {
        // Apagar todos os registros da lista
        dropdown.ClearOptions();
        // Atualizar os registros com os componentes correspodentes
        dropdown.AddOptions(options);
    }

    void AddDropdownOptions(TMP_Dropdown dropdown, List<string> options)
    {
        dropdown.AddOptions(options);
    }

    public void LimparPerfil(){
        mb_DD.value = 0;
        cpu_DD.value = 0;
        gpu_DD.value = 0;
        fonte_DD.value = 0;
        ram_DD.value = 0;
        SSD_DD.value = 0;
        HDD_DD.value = 0;
    }

    public void IncreaseSSD(){
        SSD_Total++;

        if(SSD_Total > SSD_Slots)
            SSD_Total = 0;
    }

    public void IncreaseHDD(){
        HDD_Total++;    
        
        if(HDD_Total > HDD_Slots)
            HDD_Total = 0;        
    }
}