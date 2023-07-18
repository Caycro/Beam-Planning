
import csv


#app currently doesnt work, file loading problems
#files loaded will likely need to be renamed 
#due to the way microsoft forms responses get converted into excel
#most of this app is probably deprecated due to  only needing one file now (CSV from accepted form)
#load all of the details users entered into UserDetails.CSV

#load the csv from the form into the rpogram as a dictionary
def LoadUsers():
    
    dataBase=dict
    #load the csv file into variable called database
    with open('ModelCSV.txt', mode= 'r') as data:
        csvReader = csv.DictReader(data,delimiter=",",dialect= "excel")
        for row in csv.DictReader(data):
            
            dataBase.update(row)
        
    return dataBase

#load the days that the beam is avaliable
def LoadDays(Days):
    
    with open('DaysAvaliable.txt','r') as data:
        csvReader = csv.DictReader(data,delimiter=",",dialect= "excel")
        for row in csv.DictReader(data):
            
                Days.append(row)


def AllocateBlock(user, days,finalPlan):
     #for currentDay in days:
          #if current day is not in users list of unavaliable days 
          # and is of a type which can be used by one of their blocks
          #reduce block size by 1 and allocate that day to current user by modifying final plan
          #repeat until no days avalible for that user or that users has all blocks filled
    print("WIP")


            

def main():
    userDetails = LoadUsers()
    daysAvaliable=[]
    finalPlan=[]
    
    LoadDays(daysAvaliable)
    for i in userDetails.items() -> dict_items:
        AllocateBlock(i,daysAvaliable,finalPlan)



main()