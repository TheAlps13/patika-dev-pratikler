using System;
using System.Collections.Generic;

namespace todo
{
    public static class BoardOperations
    {
        private enum line { TODO, InProgress, Done, NotFound }; // To use with MoveCard function
        public static void ListBoard(List<Card> todo, List<Card> inProgress, List<Card> done)
        {
            Console.WriteLine(Messages.TodoLine); // Todo line
            if (todo.Count == 0)
                Console.WriteLine(Messages.Empty);
            foreach (Card card in todo)
                card.Show();

            Console.WriteLine(Messages.InProgressLine);// Inprogress line
            if (inProgress.Count == 0)
                Console.WriteLine(Messages.Empty);
            foreach (Card card in inProgress)
                card.Show();

            Console.WriteLine(Messages.DoneLine); // Done line
            if (done.Count == 0)
                Console.WriteLine(Messages.Empty);
            foreach (Card card in done) 
                card.Show();
        }
        public static void AddCard(List<Card> todo)
        {
            string header, content;
            int size, appointedPersonId;

            Console.Write(Messages.EnterHeader); // Header
            header = Console.ReadLine();

            Console.Write(Messages.EnterContent); // Content
            content = Console.ReadLine();

            Console.Write(Messages.EnterSize); // Size
            size = Int32.Parse(Console.ReadLine());

            Console.Write(Messages.EnterAppointedPers); // Team member ID
            appointedPersonId = Int32.Parse(Console.ReadLine());

            todo.Add(new Card
            {
                Header = header,
                Content = content,
                Size = ((Card.CardSize)size).ToString(), // Converting enum to string
                AppointedPerson = TeamMembers.IdName[appointedPersonId]
            });
            Console.WriteLine("\nKişi başarıyla eklendi !\n");
        }
        public static void RemoveCard(List<Card> todo, List<Card> inProgress, List<Card> done)
        {
            bool isAnyRemoved = false;
            // User input
            string header;
            Console.WriteLine(Messages.SelectCardToRmv);
            Console.Write(Messages.EnterCardHeader);
            header = Console.ReadLine();

            // Find the size of longest list
            int maxCount = Math.Max(Math.Max(todo.Count, inProgress.Count), done.Count);
            for (int i = 0; i < maxCount; i++)
            {
                if (i < todo.Count)
                    if (todo[i].Header.Equals(header))
                    {
                        todo.RemoveAt(i);
                        isAnyRemoved = true;
                    }

                if (i < inProgress.Count)
                    if (inProgress[i].Header.Equals(header))
                    {
                        inProgress.RemoveAt(i);
                        isAnyRemoved = true;
                    }

                if (i < done.Count)
                    if (done[i].Header.Equals(header))
                    {
                        done.RemoveAt(i);
                        isAnyRemoved = true;
                    }
            }

            if (!isAnyRemoved)
            {
                Console.WriteLine(Messages.CardNotFound);
                Console.WriteLine(Messages.EndRmv);
                Console.WriteLine(Messages.TryAgain);
                int operationCode = Int32.Parse(Console.ReadLine());
                // End removing
                if (operationCode == 1)
                    return;
                // Recursive call until something properly removed
                if (operationCode == 2)
                    RemoveCard(todo, inProgress, done);
            }
            else
                Console.WriteLine("\nKart başarıyla silindi\n");
        }
        public static void MoveCard(List<Card> todo, List<Card> inProgress, List<Card> done)
        {
            line foundLine = line.NotFound; // The line that is the card found on
            Card card = new(); // Card to move
            // User input
            string header;
            Console.WriteLine(Messages.SelectCardToMove);
            Console.Write(Messages.EnterCardHeader);
            header = Console.ReadLine();
            // Find the size of longest list, then loop
            int maxCount = Math.Max(Math.Max(todo.Count, inProgress.Count), done.Count);
            for (int i = 0; i < maxCount; i++)
            {
                if (i < todo.Count) // Check if the card on todo line
                    if (todo[i].Header.Equals(header))
                    {
                        card = todo[i];
                        todo.RemoveAt(i);
                        foundLine = line.TODO;
                        break;
                    }

                if (i < inProgress.Count) // Check if the card on in progress line
                    if (inProgress[i].Header.Equals(header))
                    {
                        card = inProgress[i];
                        inProgress.RemoveAt(i);
                        foundLine = line.InProgress;
                        break;
                    }

                if (i < done.Count) // Check if the card on done line
                    if (done[i].Header.Equals(header))
                    {
                        card = done[i];
                        done.RemoveAt(i);
                        foundLine = line.Done;
                        break;
                    }
            }

            if (foundLine == line.NotFound) // If nothing found, end searching or retry
            {
                Console.WriteLine(Messages.CardNotFound);
                Console.WriteLine(Messages.EndOperation);
                Console.WriteLine(Messages.TryAgain);
                int operationCode = Int32.Parse(Console.ReadLine());

                if (operationCode == 1) // End operation
                    return;
                if (operationCode == 2) // Recursive call to retry
                    MoveCard(todo, inProgress, done);

            }
            else
            {   // User input
                Console.WriteLine(Messages.FoundCardInf);
                Console.WriteLine(Messages.Line + foundLine.ToString());
                card.Show();
                Console.WriteLine(Messages.SelectTheLineToMove);
                int operationCode = Int32.Parse(Console.ReadLine());
                if (operationCode < 1 || operationCode > 3) // If something wrong happened, throw an error to hell
                    throw new Exception();
                switch (operationCode)
                {
                    case 1:
                        if (!todo.Contains(card))
                            todo.Add(card);
                        break;
                    case 2:
                        if (!inProgress.Contains(card))
                            inProgress.Add(card);
                        break;
                    case 3:
                        if (!done.Contains(card))
                            done.Add(card);
                        break;
                }
                Console.WriteLine(Messages.CardMoveSuccess);
                ListBoard(todo, inProgress, done); // If everything goes well, list fresh board
                return;
            }

        }
    }
}