from flask import Flask

'initialize app'
app = Flask(__name__)

'get database'
db = SQL("sqllite:///Booking.db")

@app.route('/')
def Test():
    print("works")
    return

@app.route('/GetBlocks')
def 
