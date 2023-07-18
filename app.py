
import csv
#load all of the details users entered into UserDetails.CSV
def LoadBlocks():

    lineCount=0
    dataBase=[]
    #load the csv file into variable called database
    with open('BlockDetails.txt', mode= 'r') as blockCsvFile:
        csvReader = csv.DictReader(blockCsvFile,delimiter=",",dialect= "excel")
        for row in csvReader:
            if (lineCount>0):
               dataBase.append(row)
            lineCount+=1
    return dataBase


def LoadUsers():
    lineCount=0
    dataBase=[]
    #load the csv file into variable called database
    with open('UserDetails.txt', mode= 'r') as blockCsvFile:
        csvReader = csv.DictReader(blockCsvFile,delimiter=",",dialect= "excel")
        for row in csvReader:
            if (lineCount>0):
               dataBase.append(row)
            lineCount+=1
    return dataBase

def last(myList):
    return myList[myList.Len]

def main():
    blocks = LoadBlocks()
    users = LoadUsers()
    details = []
    for i in users:
        details.append(i)
        for j in blocks:
            if (i[0] == j[0]):
                last(details).append[blocks[1]]
                last(details).append[blocks[2]]
    for i in details:
        print(i)

main()




