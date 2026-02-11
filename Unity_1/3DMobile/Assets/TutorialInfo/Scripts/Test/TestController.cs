using cfg;
using Luban;
using System.IO;
using UnityEngine;

public class TestLubanConfig:MonoBehaviour
{
    public void Start()
    {
        string filePath = @".\Assets\TutorialInfo\Scripts\Test\TestLubanConfig\data\sale.bytes";
        Sale sale = new Sale(Load_Data(filePath)); //成功
        Debug.Log(sale.ToString());

        filePath = @".\Assets\TutorialInfo\Scripts\Test\TestLubanConfig\data\equip.bytes";
        Equip equip = new Equip(Load_Data(filePath)); //成功
        Debug.Log(equip.ToString());
    }
    private ByteBuf Load_Data(string filePath)
    {
        byte[] data = File.ReadAllBytes(filePath);
        ByteBuf byte_buf = new ByteBuf(data);
        return byte_buf;
    }
}
