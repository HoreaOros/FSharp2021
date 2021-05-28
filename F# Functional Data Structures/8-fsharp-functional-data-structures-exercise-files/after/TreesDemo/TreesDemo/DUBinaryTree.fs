module DUBinaryTree

// A simple binary tree of integers:
type Tree =
   | Leaf of int
   | Node of Tree * Tree

// Constucting an int tree:
let myIntTree : Tree =
   Node (Leaf 1, Node (Leaf 2, Leaf 3))

// A generic binary tree:
type Tree<'T> =
   | Leaf of 'T
   | Node of Tree<'T> * Tree<'T>

// Constructing a tree of strings using the generic binary tree:
let myTree : Tree<string> =
   Node (Leaf "one", Node (Leaf "two", Leaf "three"))