

import _sqlite3
from flask import Flask
db = _sqlite3.connect("Booking.db")
#initialise app

app = Flask(__name__)

'get database'


@app.route('/')
def Test():
    print("works")
    return

@app.route('/GetBlocks')
def Save_Blocks():
    ' insert into sql databases table of blocks'
    db.execute("Insert into Blocks ")
    
