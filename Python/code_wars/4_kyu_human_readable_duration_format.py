# Your task in order to complete this Kata is to write a function which formats a duration, given as a number
#   of seconds, in a human-friendly way.
#
# The function must accept a non-negative integer. If it is zero, it just returns "now". Otherwise, the
#   duration is expressed as a combination of years, days, hours, minutes and seconds.
#
# It is much easier to understand with an example:
# * For seconds = 62, your function should return
#     "1 minute and 2 seconds"
# * For seconds = 3662, your function should return
#     "1 hour, 1 minute and 2 seconds"

SEC_PER_YEAR = 31536000  # 365*24*60*60
SEC_PER_DAY = 86400  # 24*60*60
SEC_PER_HR = 3600  # 60*60
SEC_PER_MIN = 60


def format_duration(seconds):
    total = seconds

    years, seconds = divmod(seconds, SEC_PER_YEAR)
    days, seconds = divmod(seconds, SEC_PER_DAY)
    hours, seconds = divmod(seconds, SEC_PER_HR)
    minutes, seconds = divmod(seconds, SEC_PER_MIN)

    values = [years, days, hours, minutes, seconds]
    keys = ['year', 'day', 'hour', 'minute', 'second']

    result1 = []
    for index, date in enumerate(values):
        if date:
            result1.append(
                f"{date} {keys[index]}s"
                if date > 1
                else f"{date} {keys[index]}"
            )

    result2 = ", ".join(result1)
    last_comma = result2.rfind(",")

    end_result = f"{result2[:last_comma]}" \
                 f"{' and '}" \
                 f"{result2[last_comma + 2:]}" \
        if result2.count(",") >= 1 else result2

    if not total:
        return "now"
    else:
        return end_result
