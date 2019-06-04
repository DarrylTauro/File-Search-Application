******************************************************************************
*Program to Create Multiple Copies of Test File
******************************************************************************
*CopyFileApplication.exe   (To create multiple copies if Test file)
-------------------------------------------------------------------------------------------------
*Step1: Enter The Source Filename (From Current Directory Ex:test.txt)
        Sample file Test.txt has already been included in the zip package
        This file will be the one that will be copied multiple times by the Program.
        (Please make sure the Test.txt file is present in the directory where CopyFileApplication.exe is present)
        
*Step2: Enter number of file copies required.
        (Test.txt file has 20000 lines and file size is 4MB)      
        (!!!!Even if you create 200 copies the size of the target would be 200*4MB = 800MB. Please select
         a nominal count to avoid eating up of all of your disk space!!!!!!) 
         
*Step3: Enter The Target Directory Path (Ex: C:\\SearchFolder\\)
        (This path is where desired number of copies of your test file will be created)
        
        
(Wait for the Success Message :"Files Created")
-------------------------------------------------------------------------------------------------






******************************************************************************
*Program to Search Pharse/String in multiple files
******************************************************************************
*SearchPhraseApplication.exe   (To Search Pharse/String in multiple files)
-------------------------------------------------------------------------------------------------
*Step1: Enter The Target Directory Path (Ex: C:\\SearchFolder\\)
        (This is the Directory Path where multiple text files, created by the previous prorgram are present)

*Step2: Enter The Phrase or String to be searched:    (Ex:Goa)


Once phrase is entered the phrase will be searched in all the text files present in \\SearchFolder
The Output is in following format: Sl: 1 Filename:C:\Search\test1.txt Count:27342

where Sl: serial number (Just to Validate at the end the count of the files searched in the folder)
      Filename: Name of the file
      Count: Frequency of occurance of the phrase in the file.
      
Once all the files are searched the total execution time is shown as:
executionTime (x)seconds
----------------------------------------------------------------------------------------------------

        
