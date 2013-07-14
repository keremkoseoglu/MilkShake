MilkShake
=========

Milkshake is an encryption / decryption library based upon 3DES.

Purpose of this project is to demonstrate how to build a new encryption / decryption algorhytm based upon an existing one. Here are some points of interest:

    MilkShake algorhytm is based upon 3DES, with some spice
    Texts can be encrypted and decrypted using the same key
    A good & solid key must contain all English lowercase characters, numbers and space with a random order. If you don't provide the key, MilkShake will use it's default key.
    It is possible to generate different encrypted texts using the same input & key
    The key is being shifted multiple times during the encryption process

Please note that this algorhytm might neither be crack-proof, nor match the industry standards. It is merely a pet project. Feel free to use it on your applications. However, if you get in trouble because the encrypted data gets cracked or you can't decrypt some important information because of a bug or something, it is going to be your own problem. Use it at your own risk!
