using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class FileDataHandler
{
    private string dataDirPath = "";
    private string dataFileName = "";

    private bool useEncryption = false;
    private readonly string encryptionCodeWord = "yourMom";

    public FileDataHandler(string dataDirPath, string dataFileName, bool useEncryption) {
        this.dataDirPath = dataDirPath;
        this.dataFileName = dataFileName;
        this.useEncryption = useEncryption;
    }

    public GameData Load() {
        string fullPath = Path.Combine(dataDirPath, dataFileName);
        GameData loadedData = null;
        if(File.Exists(fullPath)) {
            try {
                //load serialized data from file
                string dataToLoad = "";
                using(FileStream stream = new FileStream(fullPath, FileMode.Open)) {
                    using(StreamReader reader = new StreamReader(stream)) {
                        dataToLoad = reader.ReadToEnd();
                    }
                }

                if(useEncryption) {
                    dataToLoad = EncryptDecrypt(dataToLoad);
                }

                //deserialize .json to C# object
                loadedData = JsonUtility.FromJson<GameData>(dataToLoad);
            } catch(Exception e) {
                Debug.LogError("Error occured while trying to load data from file: " + fullPath + "\n" + e);

            }
        }
        return loadedData;
    }

    public void Save(GameData data) {
        //use Path.Combine for different OS having different path separators
        string fullPath = Path.Combine(dataDirPath, dataFileName);
        try {
            //create the directory the file will be written to if it doesnt exist already
            Directory.CreateDirectory(Path.GetDirectoryName(fullPath));

            //serialize the C# game data object into .json
            string dataToStore = JsonUtility.ToJson(data, true);

            if(useEncryption) {
                dataToStore = EncryptDecrypt(dataToStore);
            }

            //write serialized data to file 
            using(FileStream stream = new FileStream(fullPath, FileMode.Create)) {
                using(StreamWriter writer = new StreamWriter(stream)) {
                    writer.Write(dataToStore);
                }
            }
        } catch(Exception e) {
            Debug.LogError("Error occured when trying to save data to file: " + fullPath + "\n" + e);
        }
    }

    //using XOR encryption in order to make it harder to modify saves
    private string EncryptDecrypt(string data) {
        string modifiedData = "";
        for (int i = 0; i < data.Length; i++) {
            modifiedData += (char) (data[i] ^ encryptionCodeWord[i % encryptionCodeWord.Length]);
        }
        return modifiedData;
    }
}
