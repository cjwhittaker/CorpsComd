Module common_variables
    Public orbat As Collection, u As cunit, phase As Integer, playerphase As Integer, gamedate As Date
    Public eq_list As Collection, event_list As Collection
    Public TOE As Collection, subunit As csubunit
    Public unittypes As Collection, unittype As cunittype
    Public scenario As String, gt As Integer, dice As Integer
    Public ph As String, nph As String
    Public ph_hqs As Collection, recovered As Collection
    Public p1_hqs As Collection, p2_HQs As Collection
    Public p1_units As Collection, p2_Units As Collection
    Public p1_orbat As Collection, p2_orbat As Collection
    Public p1_tree As Collection, p2_tree As Collection
    Public p1_cap As Integer, p2_cap As Integer, p1_sead As Integer, p2_sead As Integer
    Public ph_units As Collection, enemy As Collection
    Public smokefiredthisturn As Boolean
    Public qtypinned As Integer, qtyrepulsed As Integer, qtydestroyed As Integer
    Public topserial As Integer, oppfire As Boolean, result_option As String
    Public lowammo As Color = Color.Blue, in_ds As Color = Color.Yellow, can_observe As Color = Color.LightGreen, no_action_pts As Color = Color.LightGray
    Public nostatus As Color = Color.White, disruptedstatus As Color = Color.Red, dead As Color = Color.DarkGray, demoralisedstatus As Color = Color.DarkOrange, take_off As Color = Color.Aquamarine
    Public assaulting As Color = Color.LightSalmon, not_on_net As Color = Color.YellowGreen
    Public opportunityfire As New unit_selection, airground As New unit_selection, groundair As New unit_selection
    Public night As Boolean, dawn As Integer, dusk As Integer, twilight As Boolean
    Public sys_dir As String, g_dir As String, d_dir As String
    Public golden As Color = Color.Goldenrod, defa As Color = SystemColors.Control
    Public travel As String = "Travel", conc As String = "Conc", disp As String = "Disp"
    Public debussed As String = "debussed", embussed As String = "embussed", dismounted As String = "dismounted", unloaded As String = "unloaded", loaded As String = "loaded"
    Public fire_loss_table(,) As Integer = {{0, 0, 0, 0, 0, 0, 0, 0, -1, -1, -1, 1, 1, 1, 1, 1, 1, 2, 2, 2},
{0, 0, 0, 0, 0, 0, -1, -1, -1, -1, 1, 1, 1, 1, 1, 1, 2, 2, 2, 2},
{0, 0, 0, 0, 0, -1, -1, -1, -1, 1, 1, 1, 1, 1, 1, 2, 2, 2, 2, 3},
{0, 0, 0, 0, -1, -1, -1, -1, 1, 1, 1, 1, 1, 1, 2, 2, 2, 2, 3, 3},
{0, 0, 0, -1, -1, 1, 1, 1, 1, 1, 1, 1, 2, 2, 2, 2, 2, 3, 3, 3},
{0, 0, -1, -1, 1, 1, 1, 1, 1, 1, 1, 2, 2, 2, 2, 2, 3, 3, 3, 4},
{0, -1, -1, 1, 1, 1, 1, 1, 1, 2, 2, 2, 2, 2, 3, 3, 3, 3, 4, 4},
{-1, 1, 1, 1, 1, 1, 1, 1, 2, 2, 2, 2, 2, 3, 3, 3, 4, 4, 4, 4},
{-1, 1, 1, 1, 1, 1, 2, 2, 2, 2, 2, 3, 3, 3, 3, 4, 4, 4, 4, 5},
{1, 1, 1, 2, 2, 2, 2, 2, 2, 3, 3, 3, 3, 3, 4, 4, 4, 4, 5, 5}}
    Public direct_fire(,) As Integer = {{-1, -1, -1, -1, 0, 1, 2, 3, 4, 5, 6, 7},
{-1, -1, -1, 0, 1, 2, 3, 4, 5, 6, 7, 8},
{-1, -1, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9},
{-1, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10},
{0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11},
{1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12},
{2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13},
{3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14},
{4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15},
{5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16},
{6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17},
{7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18},
{8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19},
{9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20},
{10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21},
{11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22}}
    Public direct_fire_strength(,) As Integer = {{0, 0, 0, 1, 2, 3, 4, 6, 8, 9, 11, 12},
{0, 0, 1, 2, 3, 4, 6, 8, 9, 10, 12, 13},
{0, 1, 2, 3, 5, 6, 7, 9, 10, 12, 13, 14},
{1, 2, 3, 4, 6, 7, 8, 10, 11, 13, 14, 15},
{1, 3, 4, 5, 7, 8, 9, 11, 12, 14, 15, 16},
{2, 4, 5, 7, 8, 9, 10, 12, 13, 15, 16, 17},
{2, 4, 6, 8, 9, 10, 11, 13, 14, 16, 17, 18},
{3, 5, 7, 9, 10, 11, 12, 14, 15, 17, 18, 19},
{4, 6, 8, 10, 11, 12, 13, 15, 17, 18, 19, 20},
{5, 7, 9, 11, 12, 13, 14, 16, 18, 19, 20, 21},
{6, 8, 10, 12, 13, 14, 15, 17, 19, 20, 21, 22},
{7, 9, 11, 13, 14, 15, 16, 18, 20, 21, 22, 23},
{8, 10, 12, 14, 15, 16, 17, 19, 21, 22, 23, 24},
{9, 11, 13, 15, 16, 17, 18, 20, 22, 23, 24, 25},
{10, 12, 14, 16, 17, 18, 19, 21, 23, 24, 25, 26}}
    Public indirect_fire(,) As Integer = {{0, 0, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10},
{2, 3, 5, 7, 9, 10, 0, 0, 0, 0, 0, 0, 0},
{6, 4, 6, 8, 10, 0, 0, 0, 0, 0, 0, 0, 0},
{12, 5, 7, 9, 10, 0, 0, 0, 0, 0, 0, 0, 0},
{13, 7, 9, 10, 0, 0, 0, 0, 0, 0, 0, 0, 0}}
    Public indirect_fire_strength(,) As Integer =
{{0, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10},
{0, 1, 1, 2, 3, 4, 5, 6, 8, 9, 10, 11},
{1, 1, 2, 3, 4, 5, 6, 8, 9, 9, 10, 11},
{1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12},
{2, 3, 3, 4, 5, 6, 8, 9, 10, 11, 12, 13},
{2, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 13},
{2, 4, 5, 6, 8, 9, 10, 11, 12, 13, 14, 14},
{3, 5, 6, 7, 9, 10, 11, 12, 13, 14, 15, 15},
{3, 5, 6, 8, 10, 11, 12, 13, 14, 14, 15, 16}}
    Public cb_table(,) As Integer =
{{6, 5, 4, 3, 2, 1},
{5, 4, 3, 2, 1, 1},
{4, 3, 2, 1, 1, 1}}




End Module
