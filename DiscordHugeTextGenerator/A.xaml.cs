using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace DiscordHugeTextGenerator {
	public partial class A : Window {
		private const string g = ": ";
		private const char j = ':';
		public A() => InitializeComponent();
		private readonly Dictionary<char, string> e = new Dictionary<char, string>() {
			{'#', ":hash:" },
			{'*', ":asterisk:" },
			{'/', ":french_bread:" },
			{'!', ":exclamation:" },
			{'?', ":question:" },
			{' ', "   " },
		};
		private readonly Dictionary<string, string> h = new Dictionary<string, string>() {
			{"up!", "up"},
			{"!!", "bangbang"},
			{"!?", "interrobang"},
		};
		private readonly List<string> i = new List<string>() {
			"vs", "100","id","ng","atm","wc","abc", "ok","cool","new","free"
		};
		private readonly HashSet<string> f = new HashSet<string>() {
			"se",
			"ac","ad","ae","af","ag","ai","al","am","ao","aq","ar","as","at","au","aw","ax","az",
			"ba","bb","bd","be","bf","bo","bg","bh","bi","bj","bl","bm","bq","br","bs","bt","bv","bw","by","bz",
			"ca","cc","cd","cf","cg","ch","ci","ck","cl","cm","cn","co","cp","cr","cu","cv","cw","cx","cy","cz",
			"de","dg","dj","dk","dm","do","dz",
			"ea","ec","ee","eg","eh","er","es","et","eu",
			"fi","fj","fk","fm","fo","fr",
			"ga","gb","gd","ge","gf","gg","gh","gi","gl","gm","gn","gp","gq","gr","gs","gt","gu","gw","gy",
			"hk","hm","hn","hr","ht","hu",
			"ic","id","ie","il","im","in","io","iq","ir","is","it",
			"je","jm","jo","jp",
			"ke","kg","kh","ki","km","kn","kp","kr","kw","ky","kz",
			"la","lb","ic","li","lk","lr","ls","lt","lu","lv","ly",
			"ma","mc","md","me","mf","mg","mh","mk","ml","mm","mn","mo","mp","mq","mr","ms","mt","mu","mv","mw","mx","my","mz",
			"na","nc","ne","nf","ng","ni","nl","no","np","nr","nu","nz",
			"om",
			"pa","pe","pf","pg","ph","pk","pl","pm","pn","pr","ps","pt","pw","py",
			"qa",
			"re","ro","rs","ru","rw",
			"sa","sb","sc","sd","sg","sh","si","sj","sk","sl","sm","sn","so","sr","ss","st","sv","sx","sy","sz",
			"ta","tc","td","tf","tg","th","tj","tk","tl","tm","tn","to","tr","tt","tv","tw","tz",
			"ua","ug","um","us","uy","uz",
			"va","vc","ve","vg","vi","vn","vu",
			"wf","ws",
			"xk",
			"ye","yt",
			"za","zm","zw"
		};
		private static readonly string[] a = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
		private void B(object _, object __) {
			var a = new StringBuilder();
			var b = F.Text.ToLower();
			if (G.IsChecked != true)
				foreach (var c in b)
					B(c, a);
			else
				for (var c = 0; c < b.Length; c = B(a, b, c))
					;
			d.Text = a.ToString();
		}

		private int B(StringBuilder a, string b, int c) {
			if (c + 1 == b.Length)
				B(b[c], a);
			else if (B(b, c, out var d, a))
				c = d;
			else {
				var e = "" + b[c] + b[c + 1];
				if (f.Contains(e)) {
					a.Append(j).Append("flag_").Append(e).Append(g);
					c++;
				}
				else
					B(b[c], a);
			}
			return c;
		}

		private bool B(string a, int b, out int c, StringBuilder d) {
			c = b - 1;
			var e = a.Length - b;
			foreach (var f in h.Keys) {
				if (f.Length <= e) {
					if (a.Substring(b, f.Length) == f) {
						d.Append(j).Append(h[f]).Append(g);
						c += f.Length;
						return true;
					}
				}
			}
			foreach (var f in i) {
				if (f.Length <= e) {
					if (a.Substring(b, f.Length) == f) {
						d.Append(j).Append(f).Append(g);
						c += f.Length;
						return true;
					}
				}
			}
			return false;
		}
		private void B(char a, StringBuilder b) {
			if (a >= 'a' && a <= 'z')
				b.Append(j).Append("regional_indicator_").Append(a).Append(g);
			else if (a >= '0' && a <= '9')
				b.Append(j).Append(A.a[a - '0']).Append(g);
			else if (e.TryGetValue(a, out var v))
				b.Append(v).Append(' ');
			else if (a == '\n')
				b.Append(a);
		}

		private void D(object _, RoutedEventArgs __) => B(null, null);
		private void H(object _, RoutedEventArgs __) {
			Clipboard.SetText(d.Text);
			d.SelectionStart = 0;
			d.SelectionLength = d.Text.Length;
		}
	}
}
