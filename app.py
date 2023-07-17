

from flask import Flask
'initialize app'
app = Flask(__name__)

'get database'
db = sqlite3("sqllite:///Booking.db")

@app.route('/')
def Test():
    print("works")
    return

@app.route('/GetBlocks')
def SaveBlocks():
    'flask insert into sql database'
