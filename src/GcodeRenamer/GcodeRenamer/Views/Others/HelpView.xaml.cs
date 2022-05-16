using GcodeRenamer.ViewModels;

namespace GcodeRenamer;

public partial class HelpView : ContentPage
{
	private HelpViewModel viewModel => BindingContext as HelpViewModel;
	public HelpView(HelpViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}