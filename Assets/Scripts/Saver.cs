using UnityEngine;
using System.Collections;
using System.IO;
public class Saver : MonoBehaviour {
	
	public static string path;
	private static StreamReader file;
	
	public static void Begin(string path_=""){
		path =(path_=="")?path:path_;
		file = new StreamReader (path);
		
	}
	
	public static void Save(string name, string value_){
		string fileValue = file.ReadToEnd();
		name = "["+name+"]";
		int pos = fileValue.IndexOf(name);
		if (pos!=-1) {
			pos+=name.Length+1;
			while (fileValue[pos]!='\n') fileValue.Remove(pos,1);
				fileValue.Insert(pos, value_);
		} else {
			fileValue = fileValue +"\n"+name+":"+value_;
		}
		
	}
	
	public static string Load(string name){
		string fileValue = file.ReadToEnd();
		string result="";
		name = "["+name+"]";
		int pos = fileValue.IndexOf(name);
		if (pos!=-1) {
			while (fileValue[pos]!='\n') {
				result+=fileValue[pos];
				pos++;
			}
		}
		return result;
	}
	
	
}
