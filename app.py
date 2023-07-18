
import csv
#app currently doesnt work, file loading problems
#files loaded will likely need to be renamed due to the way microsoft forms responses get converted into excel
#most of this app is probably deprecated  
#load all of the details users entered into UserDetails.CSV
def LoadBlocks():

    lineCount=0
    dataBase = dict
    #load the csv file into variable called database
    with open('BlockDetails.txt', mode= 'r') as blockCsvFile:
        csvReader = csv.DictReader(blockCsvFile,delimiter=",",dialect= "excel")
        for row in csvReader:
            if (lineCount>0):
               dataBase+=row
            lineCount+=1
    return dataBase


def LoadUsers():
    lineCount=0
    dataBase=dict
    #load the csv file into variable called database
    with open('UserDetails.txt', mode= 'r') as blockCsvFile:
        csvReader = csv.DictReader(blockCsvFile,delimiter=",",dialect= "excel")
        for row in csvReader:
            if (lineCount>0):
               dataBase
            lineCount+=1
    return dataBase

def last(myList):
    return myList[myList.Len]

def main():
    blocks = LoadBlocks()
    users = LoadUsers()
    total = users.update(blocks)
    for i in total:
        print(i)

main()