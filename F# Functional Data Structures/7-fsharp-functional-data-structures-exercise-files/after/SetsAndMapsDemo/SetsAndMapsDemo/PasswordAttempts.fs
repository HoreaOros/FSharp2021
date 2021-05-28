module PasswordAttempts

open System
open System.Text
open System.Security.Cryptography

// Hardwired actual password:
let secretPassword = "abc123"

// Generate the MD5 hash of a string:
let StringMD5 (str : string) =
   use md5 = MD5.Create()
   md5.ComputeHash(Encoding.UTF8.GetBytes(str))

// Bind a value which sets up a reference cell of an
// empty set, and returns a function that can mutate
// the set and return the attempts count:
let AttemptsSoFar =
   let attempts = ref Set.empty
   (fun passwordHash -> 
      attempts := Set.add passwordHash !attempts
      (!attempts).Count)

// Check a password, allowing three attempts and not
// counting re-tries of the same password as extra attempts:
let CheckPassword (password : string) =
   let attempts = AttemptsSoFar (StringMD5 password)
   if attempts > 3 then
      "Too many tries"
   else
      if password = secretPassword then
         "OK"
      else
         "Try again"
