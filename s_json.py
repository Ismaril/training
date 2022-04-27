from json import JSONEncoder
import json

# JavaScript Object Notation
# -  these days json is independent of Javascript = it is general purpose
# - lightweight data format used for exchange
# - heavily used in web applications

person = {
    "firstName": "Jerry",
    "lastName": "Jane",
    "age": 28,
    "city": "New York",
    "hasChildren": False,
    "children": ["engineer", "programmer"]
}

# Convert dictionary to json. This will dump python object into json string
# Dumps (with "s") - turn to json string
person_JSON = json.dumps(person, indent=4, sort_keys=True)  # , separators=("; ", "= ")
print("Json type:\n", person_JSON)  # you can tell that it returns json, because for example False is false

# Dump - this will dump python object into file (easily speaking)
with open("text_files/person.json", "w") as file:
    json.dump(person, file, indent=4, sort_keys=True)

# Convert json back to python dict from json string
# Loads (with "s") - convert json "S"tring
person = json.loads(person_JSON)
print("python dict:\n", person)

# Covert json back to python dict from json file
with open("text_files/person.json", "r") as file:
    person_json_file = json.load(file)
    print(f"person_json_file\n", person_json_file)


# We can also convert class to json
class User:
    def __init__(self, name, age):
        self.age = age
        self.name = name


user = User("Max", 27)


# ...but we have to encode it first with function
def encode_user(object_: isinstance):
    if isinstance(object_, User):
        return {"name": object_.name, "age": object_.age}
    else:
        raise TypeError("Must enter a instance object")


# ...or with class
class EncodeUser(JSONEncoder):
    def default(self, o):
        if isinstance(o, User):
            return {"name": o.name, "age": o.age, o.__class__.__name__: True}
        return JSONEncoder.default(self, o)


# userJSON = json.dumps(encode_user(user))
# userJSON = json.dumps(user, default=encode_user)  # can write it also with function
# userJSON = json.dumps(user, cls=EncodeUser)  # can write it also with class
userJSON = EncodeUser().encode(user)
print("userJSON", userJSON)


# Decode from json back to Class object
def decode_user(dictionary):
    if User.__name__ in dictionary:
        return User(name=dictionary["name"], age=dictionary["age"])
    return dictionary


user = json.loads(userJSON, object_hook=decode_user)
print(user.name)
