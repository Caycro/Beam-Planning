

import _sqlite3
from flask import Flask
db = _sqlite3.connect("Booking.db")
#initialiseapp

app = Flask(__name__)

'get database'


@app.route('/')
def Test():
    print("works")
    return

@app.route('/GetBlocks')
def SaveBlocks():
    ' insert into sql databases table of blocks'
    
