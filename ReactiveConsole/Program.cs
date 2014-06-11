using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reactive;
using System.Reactive.Subjects;
using System.Reactive.Linq;
using System.Threading;
using System.IO;
using System.Reactive.Disposables;

namespace ReactiveConsole
{
    internal class ConsoleObserver<T> : IObserver<T>
    {
        public void OnNext(T value)
        {
            Console.WriteLine("Received value {0}", value);
        }
        public void OnError(Exception error)
        {
            Console.WriteLine("Sequence faulted with {0}", error);
        }
        public void OnCompleted()
        {
            Console.WriteLine("Sequence complete!");
        }
    }

    internal class ConsoleObservable : IObservable<string>
    {
        public IDisposable Subscribe(IObserver<string> observer)
        {
            Console.WriteLine("about to emit/push values");
            observer.OnNext("abcd");
            Thread.Sleep(3000);
            observer.OnNext("efgh");
            Thread.Sleep(3000);
            observer.OnNext("ijkl");
            Thread.Sleep(3000);
            observer.OnCompleted();
            return Disposable.Empty;
        }
    }


    public class ReactiveConsole
    {
        public static void Main (string[] args)
        {
            //blocking 
            var observable = new ConsoleObservable();
            var observer = new ConsoleObserver<string>();
            var subscription = observable.Subscribe(observer);
            subscription.Dispose();
            Console.WriteLine("Bye bye");
            Console.ReadKey(); 

            //non blocking
            Console.WriteLine("one liner");
            var source = Observable.Interval(TimeSpan.FromSeconds(1));
            var sub = source.Subscribe(
               x => Console.WriteLine(x),
               ex => Console.WriteLine("error"),
               () => Console.WriteLine("done")
               );
            Console.WriteLine("one liner");
            Console.ReadKey();
            sub.Dispose();
            Console.WriteLine("sequence stopped");
            Console.ReadLine();

            //createObservableTest();
            //observableListExamples ();
            //observableSourcesWithRuntimeErrors ();
            //observableTimerExamples ();
            //Console.WriteLine("cold observable");
            //coldObservables ();
            //Console.WriteLine("hot observable");
            //hotObservables();
            //subjectTest ();
            //proxySubject ();
        }

        private static void createObservableTest()
        {
            var observable =
                Observable.Create<string>((susbcriber) =>
                {
                    Console.WriteLine("about to hit onNext()");
                    susbcriber.OnNext("abcd");
                    susbcriber.OnNext("defg");
                    susbcriber.OnNext("hijk");
                    susbcriber.OnNext("lmop"); 
                    susbcriber.OnCompleted();
                    return () =>
                    {
                        Console.WriteLine("Observer has unsubscribed");
                    };
                });

            var subscription = observable.Subscribe(
                str =>
                {
                    Console.Write(str);
                    Console.ReadLine();
                },
                ex => { },
                () => Console.WriteLine("Done")
            );
            subscription.Dispose();
            Console.ReadLine();
        }

        private static void proxySubject() {
            var source = Observable.Interval(TimeSpan.FromSeconds(1));
            Subject<long> subject = new Subject<long>();
            var subSource = source.Subscribe(subject);
            var subSubject1 = subject.Subscribe(
                x => Console.WriteLine("Value published to observer #1: {0}", x),
                () => Console.WriteLine("Sequence Completed."));
            var subSubject2 = subject.Subscribe(
                x => Console.WriteLine("Value published to observer #2: {0}", x),
                () => Console.WriteLine("Sequence Completed."));
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            subject.OnCompleted();
            subSubject1.Dispose();
            subSubject2.Dispose();
            subSource.Dispose ();
        }

        private static void subjectTest() {
            var subject = new Subject<int> ();
            var subscription = subject.Subscribe (
                   x => Console.WriteLine ("value published by subject {0}", x),
                () => Console.WriteLine ("subject sequence completed"));
            subject.OnNext (1);
            subject.OnNext (100);
            Console.WriteLine ("press any key to continue");
            Console.ReadKey ();
            subject.OnCompleted ();
            subscription.Dispose ();
        }

        private static void hotObservables() {
            Console.WriteLine("Current Time: " + DateTime.Now);
            var source = Observable.Interval(TimeSpan.FromSeconds(1));            //creates a sequence

            IConnectableObservable<long> hot = Observable.Publish<long>(source);  // convert the sequence into a hot sequence

            IDisposable subscription1 = hot.Subscribe(                        // no value is pushed to 1st subscription at this point
                x => Console.WriteLine("Observer 1: OnNext: {0}", x),
                ex => Console.WriteLine("Observer 1: OnError: {0}", ex.Message),
                () => Console.WriteLine("Observer 1: OnCompleted"));
            Console.WriteLine("Current Time after 1st subscription: " + DateTime.Now);
            Thread.Sleep(3000);  //idle for 3 seconds
            hot.Connect();       // hot is connected to source and starts pushing value to subscribers 
            Console.WriteLine("Current Time after Connect: " + DateTime.Now);
            Thread.Sleep(3000);  //idle for 3 seconds
            Console.WriteLine("Current Time just before 2nd subscription: " + DateTime.Now);

            IDisposable subscription2 = hot.Subscribe(     // value will immediately be pushed to 2nd subscription
                x => Console.WriteLine("Observer 2: OnNext: {0}", x),
                ex => Console.WriteLine("Observer 2: OnError: {0}", ex.Message),
                () => Console.WriteLine("Observer 2: OnCompleted"));
            Console.ReadKey();        
            subscription1.Dispose ();
            subscription2.Dispose ();
        }

        private static void coldObservables() {
            IObservable<long> source = Observable.Interval(TimeSpan.FromSeconds(1));   

            IDisposable subscription1 = source.Subscribe(
                x => Console.WriteLine("Observer 1: OnNext: {0}", x),
                ex => Console.WriteLine("Observer 1: OnError: {0}", ex.Message),
                () => Console.WriteLine("Observer 1: OnCompleted"));
            Thread.Sleep(5000);  //idle for 5 seconds
            IDisposable subscription2 = source.Subscribe(
                x => Console.WriteLine("Observer 2: OnNext: {0}", x),
                ex => Console.WriteLine("Observer 2: OnError: {0}", ex.Message),
                () => Console.WriteLine("Observer 2: OnCompleted"));

            Console.WriteLine("Press any key to unsubscribe");
            Console.ReadLine();
            subscription1.Dispose();
            subscription2.Dispose();                
        }

        private static void observableTimerExamples()
        {
            Console.WriteLine ("Current time : {0}",DateTime.Now);
            var source = 
                Observable.Timer (
                    TimeSpan.FromSeconds (5), 
                    TimeSpan.FromSeconds (1)).Timestamp ();
            using (source.Subscribe (x => 
                    Console.WriteLine ("{0} : {1}",x.Value,x.Timestamp))) {
                Console.WriteLine ("Press any key to unsubscribe");
                Console.ReadKey ();
            }
            Console.WriteLine ("Press any key to exit");
            Console.ReadKey ();
        }

        private static void observableListExamples()
        {
            Console.WriteLine ("Hello World!");
            //Example 1
            foreach (int x in Enumerable.Range(1,15).Take(5)) 
            {
                Console.WriteLine ("pulled number is {0}", x);
            }
            Observable.Range (1, 15)
                .Take (5)
                .Subscribe (x => Console.WriteLine ("pushed number is {0}", x));

            Console.WriteLine ("==========================\n");
        }

        private static void observableSourcesWithRuntimeErrors() {
            try
            {
                foreach(var s in getDataFromDisk()) {
                    Console.WriteLine("from disk as enumerable {0}",s); 
                }
                Console.WriteLine("done reading string from disk");
            }
            catch(IOException io) {
                Console.WriteLine ("exception {0}", io.Message);
            }
            Console.WriteLine ("==========================\n");

            //bumpy ride
            Console.WriteLine ("Before Subscribing");
            getNetworkData()
                .ToObservable()
                .Subscribe (
                    x => Console.WriteLine("OnNext: {0}",x),
                    ex => Console.WriteLine("OnError: {0}",ex.Message),
                    () => Console.WriteLine("OnCompleted")
                )
                .Dispose();
            Console.WriteLine ("See Me?");
            Console.WriteLine ("==========================\n");
        }
            
        private static IEnumerable<string> getNetworkData() {
            yield return "abc";
            yield return "def";
            Thread.Sleep (2000);
            yield return "ghi";
            yield return "jkl";
            throw new IOException ("opps, network fault");
            //yield return "mno";
        }

        private static IEnumerable<string> getDataFromDisk() 
        {
            var strings = new string[] { "abc", "def", "hij", "klm", "opq"};
            int index = 0;
            foreach (var str in strings) {
                Thread.Sleep (200);
                yield return str;
                index++;
                if (index == 3) {
                    throw new IOException ("error reading from disk");
                }
            }
        }

        private static IObservable<string> getObservableDataFromDisk() 
        {
            var diskData = new string[] { "abc", "def", "hij", "klm", "opq"};
            return diskData.ToObservable (); 
        }
    }

}
