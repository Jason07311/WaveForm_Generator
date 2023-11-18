import csv
import math

# Function to generate cosine wave data
def generate_cosine_wave(num_points, amplitude, frequency, sampling_rate):
    time_values = [i / sampling_rate for i in range(num_points)]
    current_values = [amplitude * math.cos(2 * math.pi * frequency * t) for t in time_values]
    return time_values, current_values

# Parameters for the sine wave
num_points = 500  # Adjust the number of points as needed
amplitude = 5.0
frequency = 1.0  # Adjust the frequency as needed
sampling_rate = 100.0  # Adjust the sampling rate as needed

# Generate sine wave data
time_data, current_data = generate_cosine_wave(num_points, amplitude, frequency, sampling_rate)

# Create CSV file
csv_filename = 'cosine_wave_data.csv'
with open(csv_filename, 'w', newline='') as csv_file:
    csv_writer = csv.writer(csv_file)
    csv_writer.writerow(['Time', 'Current'])
    for time, current in zip(time_data, current_data):
        csv_writer.writerow([time, current])

print(f"CSV file '{csv_filename}' created successfully.")