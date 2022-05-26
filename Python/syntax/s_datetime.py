import datetime as d
from Python.utilities.separate_rows_in_training_files import SeparateCode

separator_line = SeparateCode()
sep = "| "
# FYI "parameters" can be gotten from methods
#   example - d.datetime.now().year (year is parameter)

# Here are some examples what can be done with datetime.

print(f"{d.MAXYEAR = }")
print(f"{d.MINYEAR = }")

# DATETIME
print(f"{d.datetime.now() = }", d.datetime.now(), sep=sep)
print(f"{d.datetime.min = }", d.datetime.min, sep=sep)
print(f"{d.datetime.fromisocalendar(year=2022, week=16, day=1) = }",
      d.datetime.fromisocalendar(year=2022, week=16, day=1),
      sep=sep)
print(f"{d.datetime.fromordinal(738_000) = }", d.datetime.fromordinal(738_000), sep=sep)
print(f"{d.datetime.utcnow() = }")
print(f"{d.datetime.max = }")
print(f"{d.datetime.today() = }")
print(f"{d.datetime.now().year = }")
print(f"{d.datetime.now().day = }")
print(f"{d.datetime.now().hour = }")
print(f"{d.datetime.now().minute = }")
print(f"{d.datetime.now().microsecond = }")

timos_1 = d.datetime(year=2022, month=4, day=30, hour=6, minute=1, second=1, microsecond=1000)
print(f"{timos_1.day = }")

timos_2 = d.date(year=2022, month=3, day=18)
print(f"{timos_2.year = }")

print(separator_line.separator())

# DATE
print(f"{d.date.today() = }")
print(f"{d.date.today().day = }")
print(f"{d.date.fromisoformat('2019-12-04').year = }")
print(f"{d.date.fromordinal(600_000).year = }")
print(f"{d.date.fromordinal(600_000).day = }")
print(f"{d.date.fromordinal(600_000) = }", d.date.fromordinal(600_000), sep=", ")

print(separator_line.separator())

# TIME
print(f"{d.time.min = }")
print(f"{d.time.max = }")
print(f"{d.time.fromisoformat('23:35:02.000384').hour = }")
print(f"{d.time.fromisoformat('23:35:02.000384').minute = }")
print(f"{d.time.fromisoformat('23:35:02.000384').second = }")
print(f"{d.time.fromisoformat('23:35:02.000384').microsecond = }")

timos_3 = d.time.fromisoformat('23:35:02.000384')
print(f"{timos_3.replace(hour=18) = }")
print(f"{timos_3.isoformat() = }")

print(separator_line.separator())

# TIMEDELTA - supports basic mathematical operations with time
print(f"{d.timedelta().max = }")
print(f"{d.timedelta().min = }")
print(f"{d.timedelta(days=0, hours=0, minutes=1, seconds=0).seconds = }")

result_1 = d.timedelta(hours=1) - d.timedelta(minutes=45)
print(f"{result_1 = }", result_1)

result_2 = d.timedelta(hours=1) + d.timedelta(minutes=45)
print(f"{result_2 = }", result_2)

print(separator_line.separator())

# TIMEZONE
print(d.timezone.utc, "utc")
print(d.timezone.min, "min")
print(d.timezone.max, "max")

custom_time_zone = d.timezone(result_1)
print(custom_time_zone, f"{custom_time_zone = }", sep=sep)
print(custom_time_zone.utcoffset(d.datetime(year=2022, month=4, day=30)), "utc offset")

print(separator_line.separator())




