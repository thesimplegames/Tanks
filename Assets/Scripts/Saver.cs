using UnityEngine;
using System.Collections;
using System.IO;
public class Saver : MonoBehaviour {
	
	public static string path;
	private static StreamReader file;
	
	public static void Begin(string path_=""){
		path =(path_=="")?path:path_;
		
	}
	
	public static void Save(string name, string value_){
		file = new StreamReader (path);
		string fileValue="";
		if (file!=null) {
			fileValue = file.ReadToEnd();
			file.Close();
		}
		
		name = "["+name+"]";
		int pos = fileValue.IndexOf(name);
		if (pos!=-1) {
			pos+=name.Length+1;
			while (fileValue[pos]!='\\') { fileValue=fileValue.Remove(pos,1);}
				fileValue = fileValue.Insert(pos, value_);
				
		} else {
			fileValue = fileValue+"\n"+name+":"+value_+"\\";
		}
		StreamWriter fileWriter = new StreamWriter(path);
		fileWriter.Write(fileValue);
		fileWriter.Close();
	}
	
	public static string Load(string name,string default_=""){
		file = new StreamReader (path);
		string fileValue="";
		if (file!=null) {
			fileValue = file.ReadToEnd();
			file.Close();
		}
		string result=default_;
		name = "["+name+"]";
		int pos = fileValue.IndexOf(name);
		if (pos!=-1) {
			result="";
			pos+=name.Length+1;
			while (fileValue[pos]!='\\') {
				result+=fileValue[pos];
				pos++;
			}
		}
		return result;
	}
	
	
}
