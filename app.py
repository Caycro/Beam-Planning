
import csv


#app currently doesnt work, file loading problems
#files loaded will likely need to be renamed 
#due to the way microsoft forms responses get converted into excel
#most of this app is probably deprecated due to  only needing one file now (CSV from accepted form)
#load all of the details users entered into UserDetails.CSV


#load the csv from the form into the program as a dictionary
def LoadUsers():
    
    dataBase=dict
    #load the csv file into variable called database
    with open('ModelCSV.txt', mode= 'r') as data:
        csvReader = csv.DictReader(data,delimiter=",",dialect= "excel")
        for row in csvReader:
            
            dataBase.update(row)
        
    return dataBase

# load the days that the beam is avaliable
# may need to be modified later currently loads from days which are allocated to be usable from the csv
# but would be better to have a file of start and end dates with dates unavalible also in file as this would require less time on human end

def LoadDays(Days):
    
    with open('DaysAvaliable.txt','r') as data:
        csvReader = csv.DictReader(data,delimiter=",",dialect= "excel")
        for row in csvReader:
            Days.append(row)


def AllocateBlock(user, days, finalPlan):
     #for currentDay in days:
          #if current day is not in users list of unavaliable days 
          # and is of a type which can be used by one of their blocks
          #reduce block size by 1 and allocate that day to current user by modifying final plan
          #repeat until no days avalible for that user or that users has all blocks filled,
          #or more then max % of allowed days has been allocated
    print("WIP")


def DisplayFinalPlan(finalPlan):
    #for i in finalPlan:
       #if i.day == empty
        #in calender make i black
       #else:
        #for admin chart make i's colour unique to user on that day (probably done by a dictionary with user and colour)

        #for other people just show its used (seperate colour other then black) 
    print("WIP")
            

def main():
    userDetails = LoadUsers()
    daysAvaliable=[]
    finalPlan=[]
    
    LoadDays(daysAvaliable)
    for i in userDetails.values():
        AllocateBlock(i, daysAvaliable, finalPlan)
    


main()