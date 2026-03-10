using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: 3 values are enqueued
    // Expected Result: The one with the highest prioriy "Nestor" should be returned
    // Defect(s) Found: None
    public void TestPriorityQueue_Priority()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Jorge", 10);
        priorityQueue.Enqueue("Nestor", 11);
        priorityQueue.Enqueue("Carlos", 8);

        var value = priorityQueue.Dequeue();

        Assert.AreEqual("Nestor", value);
    }

    [TestMethod]
    // Scenario: 3 values are enqueued (2 have the same priority)
    // Expected Result: The one with the highest prioriy and FIFO order "Jorge" should be returned
    // Defect(s) Found: "Jorge" was expected but Nestor was given, also need to remove after returning 
    public void TestPriorityQueue_FIFO_after_Priority()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Jorge", 10);
        priorityQueue.Enqueue("Nestor", 10);
        priorityQueue.Enqueue("Carlos", 8);

        var value = priorityQueue.Dequeue();

        Assert.AreEqual("Jorge", value);

        priorityQueue.Enqueue("Laura", 10);

        var value2 = priorityQueue.Dequeue();

        Assert.AreEqual("Nestor", value2);
    }

    [TestMethod]
    // Scenario: 0 values are enqueued 
    // Expected Result: InvalidOperationException with a message of "The queue is empty."
    // Defect(s) Found: None
    public void TestPriorityQueue_Queue_Empty()
    {
        var priorityQueue = new PriorityQueue();
        
        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
    }

}

